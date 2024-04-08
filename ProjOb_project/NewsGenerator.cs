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

        public List<IReportable> Objects
        { get; }

        public Queue<(IMediaVisitor, IReportable)> CrossJoinQueue
        { get; }

        public NewsGenerator(List<IMediaVisitor> visitors, List<IReportable> objects)
        {
            Visitors = visitors;
            Objects = objects;
            CrossJoinQueue = new Queue<(IMediaVisitor, IReportable)>(visitors.Count * objects.Count);
            
            foreach (IReportable obj in objects)
            {
                foreach (IMediaVisitor visitor in Visitors)
                {
                    CrossJoinQueue.Enqueue((visitor, obj));
                }
            }
        }


        public string? GenerateNextNews()
        {
            //string? report = null;
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
