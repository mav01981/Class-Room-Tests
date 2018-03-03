namespace MusicalRooms
{
    public enum Direction
    {
        Forward,
        Backward
    }
    public class Rule
    {
        public int RoomId { get; set; }
        public int Wait { get; set; }
        public Direction Direction { get; set; }

    }
}
