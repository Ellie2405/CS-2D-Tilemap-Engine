using Engine;

Vector2 pos = new Vector2(1, 1);
Vector2 size = new Vector2(8, 8);
Tilemap<RectangleTile> map = new Tilemap<RectangleTile>(size);
map.GetEnumerator();

//foreach (var item in map)
//{
//    Console.WriteLine(item.indexer);
//}



//render test
Renderer renderer = new ConsoleRenderer();
renderer.Render(map);