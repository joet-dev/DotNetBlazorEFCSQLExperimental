using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBlazorEFCSQLExperimental.Shared
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; } = false; 
        public int Priority { get; set; }
        public string? Note { get; set; }
        public DateTime Created { get; set; }
        public int Duration { get; set; }
        public DateTime Due { get; set; }
        public DateTime? Completed { get; set; }

        public override string ToString()
        {
            return $"{IsDone} - ID: {Id}: {Title} ({Note}) \n" +
                $"Prio: {Priority}\n" +
                $"Duration: {Duration} minutes\n" +
                $"Created: {Created}\n" +
                $"Due: {Due}\n" +
                $"Completed: {Completed}";
        }
    }
}
