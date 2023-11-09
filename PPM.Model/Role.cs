using System;
using System.IO;
using System.Xml.Serialization;

// Create namespace for the Project
namespace PPM.Model
{
    // Creating Project Class
    [Serializable]
    public class Role
    {
        // Creating Properties
        // Use auto-implemented properties if you don't need custom logic in getters or setters.
        public int RoleId { get; set; }

        // Use nullable reference types for nullable string properties(That's why we are using string?)
        public string? RoleName { get; set; }
    }
}