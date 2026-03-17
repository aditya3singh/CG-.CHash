using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraEnterpriseSDLC
{
    public enum RiskLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum SDLCStage
    {
        Backlog = 0,
        Requirement = 1,
        Design = 2,
        Development = 3,
        CodeReview = 4,
        Testing = 5,
        UAT = 6,
        Deployment = 7,
        Maintenance = 8
    }

    public sealed class Requirement
    {
        public int Id { get; }
        public string Title { get; }
        public RiskLevel Risk { get; }

        public Requirement(int id, string title, RiskLevel risk)
        {
            Id = id;
            Title = title;
            Risk = risk;
        }
    }

    public sealed class WorkItem
    {
        public int Id { get; }
        public string Name { get; }
        public SDLCStage Stage { get; set; }
        public HashSet<int> DependencyIds { get; }

        public WorkItem(int id, string name, SDLCStage stage)
        {
            Id = id;
            Name = name;
            Stage = stage;
            DependencyIds = new HashSet<int>();
        }
    }

    public sealed class BuildSnapshot
    {
        public string Version { get; }
        public DateTime Timestamp { get; }

        public BuildSnapshot(string version)
        {
            Version = version;
            Timestamp = DateTime.Now;
        }
    }

    public sealed class AuditLog
    {
        public DateTime Time { get; }
        public string Action { get; }

        public AuditLog(string action)
        {
            Time = DateTime.UtcNow;
            Action = action;
        }
    }

    public sealed class QualityMetric
    {
        public string Name { get; }
        public double Score { get; }

        public QualityMetric(string name, double score)
        {
            Name = name;
            Score = score;
        }
    }

    public sealed class EnterpriseSDLCEngine
    {
        private List<Requirement> _requirements;
        private Dictionary<int, WorkItem> _workItemRegistry;
        private SortedDictionary<SDLCStage, List<WorkItem>> _stageBoard;
        private Queue<WorkItem> _executionQueue;
        private Stack<BuildSnapshot> _rollbackStack;
        private HashSet<string> _uniqueTestSuites;
        private LinkedList<AuditLog> _auditLedger;
        private SortedList<double, QualityMetric> _releaseScoreboard;

        private int _requirementCounter;
        private int _workItemCounter;

        public EnterpriseSDLCEngine()
        {
            _requirements = new List<Requirement>();
            _workItemRegistry = new Dictionary<int, WorkItem>();
            _stageBoard = new SortedDictionary<SDLCStage, List<WorkItem>>();

            foreach (SDLCStage stage in Enum.GetValues(typeof(SDLCStage)))
            {
                _stageBoard[stage] = new List<WorkItem>();
            }

            _executionQueue = new Queue<WorkItem>();
            _rollbackStack = new Stack<BuildSnapshot>();
            _uniqueTestSuites = new HashSet<string>();
            _auditLedger = new LinkedList<AuditLog>();
            _releaseScoreboard = new SortedList<double, QualityMetric>();

            _requirementCounter = 0;
            _workItemCounter = 0;
        }

        public void AddRequirement(string title, RiskLevel risk)
        {
            Requirement requirement = new Requirement(_requirementCounter, title, risk);
            _requirementCounter++;

            _requirements.Add(requirement);
            _auditLedger.AddLast(new AuditLog($"Requirement added: {title} [{risk}]"));
        }

        public WorkItem CreateWorkItem(string name, SDLCStage stage)
        {
            WorkItem item = new WorkItem(_workItemCounter, name, stage);
            _workItemCounter++;

            _workItemRegistry[item.Id] = item;
            _stageBoard[stage].Add(item);

            _auditLedger.AddLast(new AuditLog($"WorkItem created: {name} at stage {stage}"));
            return item;
        }

        public void AddDependency(int workItemId, int dependsOnId)
        {
            if (_workItemRegistry.ContainsKey(workItemId) &&
                _workItemRegistry.ContainsKey(dependsOnId))
            {
                _workItemRegistry[workItemId].DependencyIds.Add(dependsOnId);
                _auditLedger.AddLast(new AuditLog(
                    $"Dependency added: WorkItem {workItemId} depends on {dependsOnId}"));
            }
        }

        public void PlanStage(SDLCStage stage)
        {
            foreach (WorkItem item in _stageBoard[stage])
            {
                bool valid = item.DependencyIds.All(id =>
                    _workItemRegistry[id].Stage > stage);

                if (valid)
                {
                    _executionQueue.Enqueue(item);
                }
            }

            _auditLedger.AddLast(new AuditLog($"Stage planned: {stage}"));
        }

        public void ExecuteNext()
        {
            if (_executionQueue.Count == 0)
                return;

            WorkItem item = _executionQueue.Dequeue();
            SDLCStage previousStage = item.Stage;

            if (item.Stage < SDLCStage.Maintenance)
                item.Stage++;

            _stageBoard[previousStage].Remove(item);
            _stageBoard[item.Stage].Add(item);

            _auditLedger.AddLast(new AuditLog(
                $"Executed WorkItem {item.Id}: {previousStage} → {item.Stage}"));
        }

        public void RegisterTestSuite(string suiteId)
        {
            _uniqueTestSuites.Add(suiteId);
            _auditLedger.AddLast(new AuditLog($"Test suite registered: {suiteId}"));
        }

        public void DeployRelease(string version)
        {
            BuildSnapshot snapshot = new BuildSnapshot(version);
            _rollbackStack.Push(snapshot);
            _auditLedger.AddLast(new AuditLog($"Release deployed: {version}"));
        }

        public void RollbackRelease()
        {
            if (_rollbackStack.Count == 0)
                return;

            BuildSnapshot snapshot = _rollbackStack.Pop();
            _auditLedger.AddLast(new AuditLog($"Rollback to version: {snapshot.Version}"));
        }

        public void RecordQualityMetric(string metricName, double score)
        {
            if (_releaseScoreboard.ContainsKey(score))
                return;

            _releaseScoreboard.Add(score, new QualityMetric(metricName, score));
        }

        public void PrintAuditLedger()
        {
            foreach (AuditLog log in _auditLedger)
            {
                Console.WriteLine($"{log.Time:u} - {log.Action}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            EnterpriseSDLCEngine engine = new EnterpriseSDLCEngine();

            engine.AddRequirement("User Login Feature", RiskLevel.Medium);
            engine.AddRequirement("Payment Gateway Integration", RiskLevel.High);

            var wi1 = engine.CreateWorkItem("Design Login Module", SDLCStage.Design);
            var wi2 = engine.CreateWorkItem("Develop Login Module", SDLCStage.Development);

            engine.AddDependency(wi2.Id, wi1.Id);

            engine.PlanStage(SDLCStage.Design);
            engine.ExecuteNext();

            engine.RegisterTestSuite("LOGIN_TEST_SUITE");
            engine.DeployRelease("v1.0.0");
            engine.RollbackRelease();

            engine.RecordQualityMetric("Code Coverage", 92.5);

            Console.WriteLine("\n=== AUDIT LEDGER ===");
            engine.PrintAuditLedger();

            Console.ReadLine();
        }
    }
}
