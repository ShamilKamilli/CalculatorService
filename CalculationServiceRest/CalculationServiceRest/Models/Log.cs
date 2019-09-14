using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CalculationServiceRest.Models
{
    public class Log : BaseEntity
    {
        [ForeignKey("MethodType"),Column(name:"METHOD_TYPE")]
        public int ParentId { get; set; }

        [Required,Column(name:"INSERT_DATE")]
        public TimeSpan InsertDate { get; set; }

        [Required,Column(name:"VALUE")]
        public string Value { get; set; }

        public virtual MethodType MethodType { get; set; }
    }
}
