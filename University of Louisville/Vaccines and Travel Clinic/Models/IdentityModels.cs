using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> 
            GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        // Use a sensible display name for views:
        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }

        // Concatenate the address info for display in tables and such:
        public string DisplayAddress
        {
            get
            {
                string dspAddress = string.IsNullOrWhiteSpace(this.Address) ? string.Empty : this.Address;
                string dspCity = string.IsNullOrWhiteSpace(this.City) ? string.Empty : this.City;
                string dspState = string.IsNullOrWhiteSpace(this.State) ? string.Empty : this.State;
                string dspPostalCode = string.IsNullOrWhiteSpace(this.PostalCode) ? string.Empty : this.PostalCode;
                return string.Format("{0} {1} {2} {3}", dspAddress, dspCity, dspState, dspPostalCode);
            }
        }

        public string DisplayName
        {
            get
            {
                string dspFirstName = string.IsNullOrWhiteSpace(this.FirstName) ? string.Empty : this.FirstName;
                string dspLastName = string.IsNullOrWhiteSpace(this.FirstName) ? string.Empty : this.LastName;
                return string.Format("{0}, {1}", dspLastName, dspFirstName);
            }
        }

        public string DisplayDOB
        {
            get
            {
                string dspDOB = string.IsNullOrWhiteSpace(this.DateOfBirth) ? string.Empty : this.DateOfBirth;
                return dspDOB;
            }
        }
    }


    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
        
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}