using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.task
{
    internal class Task {
        private string description { get; set; }
        private DateTime? deadLine { get; set; }
        private bool completed { get; set; }

        internal Task(string description, DateTime? deadLine = null) {
            this.description = description;
            this.deadLine = deadLine;
            this.completed = false;
        }

        internal void setCompleted(bool completed) { 
            this.completed = completed;
        }

        internal string toString() {
            string state = completed ? "Completada-" : "Pendiente-";
            return $"{state} {description} - Fecha Límite: {(deadLine.HasValue ? deadLine.Value.ToShortDateString() : "Sin fecha Limite")}";
        }
    }
}
