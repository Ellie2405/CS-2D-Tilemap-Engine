using Engine;

Vector2 pos = new Vector2(1, 1);
Vector2 size = new Vector2(8, 8);
Tilemap<RectangleTile> map = new Tilemap<RectangleTile>(size);
map.GetEnumerator();

map.TileObjectCreator(new Vector2(0f, 0f), "pawn1", 1);

CheckersEngine CE = new CheckersEngine();
CE.Start();

//render test
Renderer renderer = new ConsoleRenderer();
renderer.NewObject(typeof(TestObject), 'P');
renderer.NewObject(typeof(Man), 'M');
renderer.Render(CE.map);

class TestObject2 : TileObject
{
    public TestObject2()
    {
    }

    public override object Clone()
    {
        throw new NotImplementedException();
    }

    public override void Move(Vector2 availableMove)
    {
        throw new NotImplementedException();
    }
}