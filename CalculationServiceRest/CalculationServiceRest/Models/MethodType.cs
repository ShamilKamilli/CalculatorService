using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalculationServiceRest.Models
{
    public class MethodType:BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        [Required,Column(name: "INSERT_DATE")]
        public TimeSpan InsertDate { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
