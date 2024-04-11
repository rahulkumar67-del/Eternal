using System;

class Player
{
    public float x;
    public float y;
    public float z;

    public Player(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public void CollideWithDoor(Door door)
    {
        if (this.x == door.x && this.y == door.y)
        {
            Teleport(door.targetX, door.targetY, door.targetZ);
        }
    }

    private void Teleport(float targetX, float targetY, float targetZ)
    {
        this.x = targetX;
        this.y = targetY;
        this.z = targetZ;
    }
}

class Door
{
    public float x;
    public float y;
    public float targetX;
    public float targetY;
    public float targetZ;

    public Door(float x, float y, float targetX, float targetY, float targetZ)
    {
        this.x = x;
        this.y = y;
        this.targetX = targetX;
        this.targetY = targetY;
        this.targetZ = targetZ;
    }
}

