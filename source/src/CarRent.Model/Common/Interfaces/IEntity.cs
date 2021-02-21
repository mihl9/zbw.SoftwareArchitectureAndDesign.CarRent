using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Model.Common.Interfaces
{
    public interface IEntity<T>
    {
        /// <summary>
        /// Contains the Identification of the Data-set
        /// </summary>
        [Key]
        T Id { get; set; }
    }
}
