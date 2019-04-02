using Abp.Domain.Entities;
using Abp.GeneralTree;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace AgentPurchaseManagementPlatform.Logistics
{

    [Table("Warehouses")]
    public class Warehouse : Entity<long>, IGeneralTree<Warehouse, long>
    {
        [Required(ErrorMessage = "不能为空")]
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public int Level { get; set; }
        public Warehouse Parent { get; set; }
        public long? ParentId { get; set; }

        [JsonIgnore]
        public ICollection<Warehouse> Children { get; set; }
    }
}
