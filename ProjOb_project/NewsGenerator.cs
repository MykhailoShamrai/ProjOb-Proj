using ProjOb_project.Items;
using ProjOb_project.Visitors.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb_project
{
    internal class NewsGenerator
    {
        public List<IMediaVisitor> Visitors
        { get; }

        public List<IReportable> ReportableItems
        { get; }

        /// <summary>
        /// Queue for cartesian product of IMediaVisitor objects and IReportable object 
        /// </summary>
        public Queue<(IMediaVisitor, IReportable)> CrossJoinQueue
        { get; }

        /// <summary>
        /// Contructor for NewsGenerator, that creates also CrossJoinQueue
        /// </summary>
        /// <param name="visitors">List of IMediaVisitor objects for which generation of news is required</param>
        /// <param name="objects">List of IReportable objects for which generation of news is required</param>
        public NewsGenerator(List<IMediaVisitor> visitors, List<IReportable> objects)
        {
            Visitors = visitors;
            ReportableItems = objects;
            CrossJoinQueue = new Queue<(IMediaVisitor, IReportable)>(visitors.Count * objects.Count);

            foreach (IReportable obj in objects)
            {
                foreach (IMediaVisitor visitor in Visitors)
                {
                    CrossJoinQueue.Enqueue((visitor, obj));
                }
            }
        }

        /// <summary>
        /// Mrthod for generating news from CrossJoinQueue. 
        /// </summary>
        /// <returns>If news was created, string will be returne. Otherwise null will be passed</returns>
        public string? GenerateNextNews()
        {
            (IMediaVisitor, IReportable) current;

            try
            {
                current = CrossJoinQueue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return current.Item2.acceptMediaVisitor(current.Item1);
        }
    }
}
