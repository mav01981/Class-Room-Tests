using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicalRooms
{
    public class Events
    {
        private ConcurrentDictionary<string, string> CurrentLocation;
        private Dictionary<int, string> rooms;
        private Dictionary<int, Person> people;

        private bool isRunning = true;

        public Events(Dictionary<int, Person> people, Dictionary<int, string> rooms)
        {
            this.people = people;
            this.rooms = rooms;
            this.Output = new List<string>();
            this.CurrentLocation = new ConcurrentDictionary<string, string>();

            foreach (Person person in this.people.Values)
            {
                this.CurrentLocation.AddOrUpdate(person.FullName, rooms[person.Rules.RoomId].ToString(), (key, oldValue) => oldValue);
                Output.Add($"{person.FullName} has starts in room {rooms[person.Rules.RoomId].ToString()}");
            }
        }

        public ConcurrentDictionary<string, string> Locations => this.CurrentLocation;

        public List<String> Output { get; set; }

        public void Start()
        {
            Task[] taskArray = new Task[people.Count];

            for (int i = 1; i <= people.Count; i++)
            {
                Person person = people[i];
                taskArray[i - 1] = new Task(() => PersonMove(person));
            }

            Parallel.ForEach<Task>(taskArray, (t) => { t.Start(); });
            Task.WaitAll(taskArray.ToArray());
            return;
        }
        private bool IsValid(string room)
        {
            if (CurrentLocation.Where(x => x.Value.Contains(room)).Count() == people.Count()) 
                return false;

            return true;
        }
        void PersonMove(Person person)
        {
            while (isRunning)
            {
                foreach (var room in rooms)
                {
                    Thread.Sleep(person.Rules.Wait);

                    string location;
                    if (CurrentLocation.TryGetValue(person.FullName, out location))
                    {
                        if (room.Value.Contains(location))
                        {
                            if (room.Key == rooms.Keys.Count) //Last record in dictionary, begin again
                            {
                                if (IsValid(room.Value))
                                {
                                    if (CurrentLocation.TryUpdate(person.FullName, rooms[1], rooms[room.Key]))
                                        Output.Add($"{person.FullName} has moved to the { rooms[1]} from the {room.Value}");
                                }

                            }
                            else
                            {
                                if (IsValid(room.Value))
                                {
                                    if (CurrentLocation.TryUpdate(person.FullName, rooms[room.Key + 1], rooms[room.Key]))
                                        Output.Add($"{person.FullName} has moved to the { rooms[room.Key + 1]} from the {room.Value}");
                                }
                            }
                        }

                        if (!IsValid(room.Value))
                        {
                            isRunning = false;
                            break;
                        }
                    }
                }
            }
        }
    }
}
