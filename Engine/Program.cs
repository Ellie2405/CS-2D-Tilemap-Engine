using Engine;

Vector2 pos = new Vector2(1, 1);
Vector2 size = new Vector2(8, 8);
Tilemap<RectangleTile> map = new Tilemap<RectangleTile>(size);
map.GetEnumerator();

map.TileObjectCreator(new Vector2(0f, 0f), "pawn1", 1);



//render test
Renderer renderer = new ConsoleRenderer();
renderer.NewObject(TestObject.Sample(), 'P');
renderer.Render(map);






