namespace Test;

public class KDNode
{
    public Entity Entity { get; init; }
    public KDNode? Left { get; set; }
    public KDNode? Right { get; set; }

    public KDNode(Entity entity)
    {
        Entity = entity;
    }
}