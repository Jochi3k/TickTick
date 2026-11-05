using Engine;
using Microsoft.Xna.Framework;

/// <summary>
/// Represents a rocket enemy that flies horizontally through the screen.
/// </summary>
class RocketRed : AnimatedGameObject
{
    Level level;
    Vector2 startPosition;
    const float speed = 500;

    public RocketRed(Level level, Vector2 startPosition, bool facingLeft)
        : base(TickTick.Depth_LevelObjects)
    {
        this.level = level;

        LoadAnimation("Sprites/LevelObjects/RocketRed/spr_rocketred@3", "rocketred", true, 0.1f);
        PlayAnimation("rocketred");
        SetOriginToCenter();

        sprite.Mirror = facingLeft;
        if (sprite.Mirror)
        {
            velocity.X = -speed;
            this.startPosition = startPosition + new Vector2(2 * speed, 0);
        }
        else
        {
            velocity.X = speed;
            this.startPosition = startPosition - new Vector2(2 * speed, 0);
        }
        Reset();
    }

    public override void Reset()
    {
        // go back to the starting position
        localPosition = startPosition;
    }
    public void Spawn()
    {
        if (sprite.Mirror)
        {
            LocalPosition = new Vector2(level.BoundingBox.Right, startPosition.Y) + new Vector2(2 * speed, 0);
        }
        else
        {
            LocalPosition = new Vector2(level.BoundingBox.Left, startPosition.Y) - new Vector2(2 * speed, 0);
        }
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        // if the rocket has left the screen, reset it
        if (sprite.Mirror && BoundingBox.Right < level.BoundingBox.Left)
            Spawn();
        else if (!sprite.Mirror && BoundingBox.Left > level.BoundingBox.Right)
            Spawn();

        // if the rocket touches the player, the player dies
        if (level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player))
            level.Player.Die();
    }
}
