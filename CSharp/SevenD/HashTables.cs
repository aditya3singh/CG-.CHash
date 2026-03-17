using System;
using System.Collections;
using System.Collections.Generic;

class HashTabless
{
    public static void HashTablessArr()
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("one", 1);
        hashtable.Add("two", 2);
        hashtable.Add("three", 3);
        foreach(int hashElement in hashtable.Keys)
        {
            Console.WriteLine("Key: " + hashElement + ", Value: " + hashtable[hashElement]);

        }

    }

}
//difference between hashtable and dictionary
//1. Hashtable is non-generic collection whereas Dictionary is generic collection.
//2. Hashtable allows null key and null values whereas Dictionary does not allow null key but allows null values.
//3. Hashtable is synchronized (thread-safe) whereas Dictionary is not synchronized.
//4. Hashtable is generally slower than Dictionary due to boxing and unboxing of value types.
//5. Dictionary provides better performance and type safety compared to Hashtable.
//6. Hashtable is part of System.Collections namespace whereas Dictionary is part of System.Collections.Generic namespace.
//7. Dictionary uses a hash table internally to store key-value pairs, while Hashtable uses an array of buckets.
//8. In Hashtable, keys and values are of type object, while in Dictionary, keys and values are of specified types.