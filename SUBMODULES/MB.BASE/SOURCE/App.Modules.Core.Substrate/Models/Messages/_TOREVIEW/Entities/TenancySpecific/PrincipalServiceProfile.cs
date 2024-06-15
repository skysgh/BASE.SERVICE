using App.Base.Shared.Models.Entities;
using App.Base.Shared.Models.Entities.TenancySpecific;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Shared.Models.Entities.TenancySpecific
{



    /// <summary>
    /// The Service Profile (ie Subscription)
    /// to which a <c>Plan</c> plan is associated.
    /// <para>
    /// We are not associating a <c>ServicePlan</c> 
    /// to a <see cref="Principal"/> directly
    /// to the 
    /// </para>
    /// </summary>
    public class PrincipalServiceProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase {



        // Not needed: Already part of the base class:
        ////public virtual Guid TenantFK { get; set; }

        /// <summary>
        /// The Tenant this record belongs to.
        /// </summary>
        public virtual Tenant? Tenant { get; set; }


        /// <summary>
        /// A <see cref="PrincipalServiceProfile"/> most often 
        /// will be signed up to one <c>ServiceProfile</c>.
        /// <para>
        /// But there are cases where the Tenancy is signed 
        /// up to multiple.
        /// </para>
        /// </summary>
        public virtual ICollection<PrincipalServiceProfileServicePlanAllocation> ServicePlans { 
            get { return _servicePlans ?? (_servicePlans = new Collection<PrincipalServiceProfileServicePlanAllocation>()); }
        }
        ICollection<PrincipalServiceProfileServicePlanAllocation>? _servicePlans;


        /// <summary>
        /// The collection of direct Service Allocations.
        /// <para>
        /// Consider this as overrides of the default list of services 
        /// defined within the <see cref="ServicePlanDefinition"/>
        /// associated to this <see cref="PrincipalServiceProfile"/>.
        /// </para>
        /// </summary>
        public virtual ICollection<PrincipalServiceProfileServiceOfferingAllocation> Services {
            get { 
                return _services ?? 
                    (_services 
                    = new Collection<PrincipalServiceProfileServiceOfferingAllocation>()); } }
        ICollection<PrincipalServiceProfileServiceOfferingAllocation>? _services;

    }

}
