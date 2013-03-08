using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel.DataAnnotations;

namespace QuickStart.Model
{
    public enum PriorityLevel
    {
        Low = 0,
        Important,
        Critical
    }

    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        public int ItemNumber
        {
            get; set;            
        }

        [Required]
        public string ItemTask
        {
            get; set;
        }       

        public QuickStart.Model.ToDo ToDomainToDo()
        {
            return new ToDo
            {
                ItemNumber = this.ItemNumber,
                ItemTask = this.ItemTask
            };
            
        }

        public ToDo()
        {

        }

        public ToDo(int itemNum, string itemTask) 
        {
            ItemNumber = itemNum;
            ItemTask = itemTask;
        }

    }
}