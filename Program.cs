using System.Drawing;

namespace Test;

class Program
{
    static void Main(string[] args)
    {
        KDTree kdTree = new KDTree();

        kdTree.Insert(new Entity() { PointStart = new Point(1, 1), PointEnd = new Point(3, 3) });
        kdTree.Insert(new Entity() { PointStart = new Point(4, 4), PointEnd = new Point(6, 6) });
        kdTree.Insert(new Entity() { PointStart = new Point(2, 2), PointEnd = new Point(5, 5) });
        kdTree.Insert(new Entity() { PointStart = new Point(7, 7), PointEnd = new Point(9, 9) });

        Entity searchRect = new() { PointStart = new Point(6, 6), PointEnd = new Point(7, 7) };

        List<Entity> intersectingRectangles = kdTree.Search(searchRect);

        Console.WriteLine("Intersecting Rectangles:");
        foreach (Entity entity in intersectingRectangles)
        {
            Console.WriteLine($"({entity.PointStart.X}, {entity.PointStart.Y}) - ({entity.PointEnd.X}, {entity.PointEnd.Y})");
        }
    }
}
