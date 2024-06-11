namespace Test;

public class KDTree
{
    private KDNode? root;

    public KDTree()
    {
        root = null;
    }

    public void Insert(Entity entity)
    {
        root = InsertRecursive(root, entity, 0);
    }

    private KDNode InsertRecursive(KDNode? node, Entity entity, int depth)
    {
        if (node == null)
            return new KDNode(entity);

        int axis = depth % 2;
        if (axis == 0)
        {
            if (entity.PointStart.X < node.Entity.PointStart.X)
                node.Left = InsertRecursive(node.Left, entity, depth + 1);
            else
                node.Right = InsertRecursive(node.Right, entity, depth + 1);
        }
        else
        {
            if (entity.PointStart.Y < node.Entity.PointStart.Y)
                node.Left = InsertRecursive(node.Left, entity, depth + 1);
            else
                node.Right = InsertRecursive(node.Right, entity, depth + 1);
        }

        return node;
    }

    public List<Entity> Search(Entity entity)
    {
        List<Entity> result = [];
        SearchRecursive(root, entity, 0, result);
        return result;
    }

    private void SearchRecursive(KDNode? node, Entity entity, int depth, List<Entity> result)
    {
        if (node == null)
            return;

        if (IsEntitiesIntersects(entity, node.Entity))
            result.Add(node.Entity);

        int axis = depth % 2;
        if (axis == 0)
        {
            if (entity.PointStart.X <= node.Entity.PointStart.X)
                SearchRecursive(node.Left, entity, depth + 1, result);
            if (entity.PointEnd.X >= node.Entity.PointStart.X)
                SearchRecursive(node.Right, entity, depth + 1, result);
        }
        else
        {
            if (entity.PointStart.Y <= node.Entity.PointStart.Y)
                SearchRecursive(node.Left, entity, depth + 1, result);
            if (entity.PointEnd.Y >= node.Entity.PointStart.Y)
                SearchRecursive(node.Right, entity, depth + 1, result);
        }
    }

    private bool IsEntitiesIntersects(Entity entity1, Entity entity2)
    {
        return !(entity2.PointStart.X > entity1.PointEnd.X || entity2.PointEnd.X < entity1.PointStart.X || entity2.PointStart.Y > entity1.PointEnd.Y || entity2.PointEnd.Y < entity1.PointStart.Y);
    }
}