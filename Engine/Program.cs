using Engine;

Vector2 pos = new Vector2(1, 1);
RectangleTile recTile = new RectangleTile(pos);
Tilemap map = new Tilemap(recTile, 8, 8);
map.GetEnumerator();
Console.WriteLine($"This map has {map.Count()} items.");

//foreach (var item in map)
//{
//    Console.WriteLine();
//}