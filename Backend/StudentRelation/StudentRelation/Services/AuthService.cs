using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StudentRelation.DTOs;
using StudentRelation.Models;

namespace StudentRelation.Services;

public class AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
{
    public async Task<AuthResponseDto?> RegisterAsync(RegisterDto dto)
    {
        var user = new ApplicationUser { UserName = dto.Username, Email = dto.Email, FullName = dto.FullName };
        var result = await userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded) return null;

        // Ensure role exists and assign it
        if (!await roleManager.RoleExistsAsync(dto.Role))
            await roleManager.CreateAsync(new IdentityRole(dto.Role));

        await userManager.AddToRoleAsync(user, dto.Role);

        return await LoginAsync(new LoginDto { Username = dto.Username, Password = dto.Password });
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await userManager.FindByNameAsync(dto.Username);
        if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password)) return null;

        var roles = await userManager.GetRolesAsync(user);
        var token = GenerateJwtToken(user, roles);

        return new AuthResponseDto
        {
            Token = token,
            Username = user.UserName!,
            Email = user.Email!,
            Roles = roles.ToList()
        };
    }

    private string GenerateJwtToken(ApplicationUser user, IList<string> roles)
    {
        var claims = new List<Claim> {
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.NameIdentifier, user.Id)
        };
        foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}