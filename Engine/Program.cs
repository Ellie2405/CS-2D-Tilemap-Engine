using Engine;

Vector2 pos = new Vector2(1, 1);
RectangleTile recTile = new RectangleTile(pos);
Tilemap map = new Tilemap(recTile, 8, 8);
map.GetEnumerator();
Vector2 index = new Vector2(1, 3);

foreach (var item in map)
{
    Console.WriteLine(item.position);
    Console.WriteLine();

}







