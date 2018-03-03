using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MusicalRooms
{
    public class Test
    {
        private readonly ITestOutputHelper output;


        public Test(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Users_Meet_At_The_Start()
        {
            var rooms = new Dictionary<int, string>()
            {
                { 1,"Kitchen" },
                { 2,"Study" },
                { 3,"Living Room" }
            };
            var people = new Dictionary<int, Person>()
            {
                {
                    1,
                    new Person(){
                        FullName="Tim",
                        Rules = new Rule()
                        {
                            Wait=1000,
                            RoomId =1
                        }
                    }
                },
                  {
                    2,
                    new Person(){
                        FullName="James",
                        Rules = new Rule()
                        {
                            Wait=1000,
                            RoomId =1
                        }
                    }
                }
            };

            var newEvent = new Events(people, rooms);
            newEvent.Start();

            foreach (var text in newEvent.Output)
            {
                output.WriteLine(text);
            }

            Assert.Equal("Kitchen", newEvent.Locations.Select(x => x.Value).First());
        }


        [Fact]
        public void Users_Meet_In_The_Study()
        {
            var rooms = new Dictionary<int, string>()
            {
                { 1,"Kitchen" },
                { 2,"Study" },
                { 3,"Living Room" }
            };

            var people = new Dictionary<int, Person>()
            {
                {
                    1,
                    new Person(){
                        FullName="Tim",
                        Rules = new Rule()
                        {
                            Wait=16000,
                            RoomId =2
                        }
                    }
                },
                  {
                    2,
                    new Person(){
                        FullName="James",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                }

            };

            var newEvent = new Events(people, rooms);
            newEvent.Start();

            foreach (var text in newEvent.Output)
            {
                output.WriteLine(text);
            }
            Assert.True(newEvent.Locations.Where(x => x.Value.Contains("Study")).Count() == people.Count());
        }
        [Fact]
        public void Users_Meet_In_The_Study_Two_People_TravelingTogether()
        {
            var rooms = new Dictionary<int, string>()
            {
                { 1,"Kitchen" },
                { 2,"Study" },
                { 3,"Living Room" }
            };

            var people = new Dictionary<int, Person>()
            {
                {
                    1,
                    new Person(){
                        FullName="Tim",
                        Rules = new Rule()
                        {
                            Wait=15000,
                            RoomId =2
                        }
                    }
                },
                  {
                    2,
                    new Person(){
                        FullName="James",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                },
                {  3,
                    new Person(){
                        FullName="Robert",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                }

            };

            var newEvent = new Events(people, rooms);
            newEvent.Start();

            foreach (var text in newEvent.Output)
            {
                output.WriteLine(text);
            }

            Assert.True(newEvent.Locations.Where(x => x.Value.Contains("Study")).Count() == people.Count());
        }

        [Fact]
        public void Users_Meet_In_The_Study_Three_People_TravelingTogether()
        {
            var rooms = new Dictionary<int, string>()
            {
                { 1,"Kitchen" },
                { 2,"Study" },
                { 3,"Living Room" }
            };

            var people = new Dictionary<int, Person>()
            {
                {
                    1,
                    new Person(){
                        FullName="Tim",
                        Rules = new Rule()
                        {
                            Wait=15000,
                            RoomId =2
                        }
                    }
                },
                  {
                    2,
                    new Person(){
                        FullName="James",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                },
                {  3,
                    new Person(){
                        FullName="Robert",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                }
                ,
                {  4,
                    new Person(){
                        FullName="Greg",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                }

            };

            var newEvent = new Events(people, rooms);
            newEvent.Start();

            foreach (var text in newEvent.Output)
            {
                output.WriteLine(text);
            }
            Assert.True(newEvent.Locations.Where(x => x.Value.Contains("Study")).Count() == people.Count());
        }


        [Fact]
        public void Users_Meet_In_The_Study_Four_People_TravelingTogether()
        {
            var rooms = new Dictionary<int, string>()
            {
                { 1,"Kitchen" },
                { 2,"Study" },
                { 3,"Living Room" }
            };

            var people = new Dictionary<int, Person>()
            {
                {
                    1,
                    new Person(){
                        FullName="Tim",
                        Rules = new Rule()
                        {
                            Wait=15000,
                            RoomId =2
                        }
                    }
                },
                  {
                    2,
                    new Person(){
                        FullName="James",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                },
                {  3,
                    new Person(){
                        FullName="Robert",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                }
                ,
                {  4,
                    new Person(){
                        FullName="Greg",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                },
                  {  5,
                    new Person(){
                        FullName="Bob",
                        Rules = new Rule()
                        {
                            Wait=7000,
                            RoomId =1
                        }
                    }
                }

            };

            var newEvent = new Events(people, rooms);
            newEvent.Start();

            foreach (var text in newEvent.Output)
            {
                output.WriteLine(text);
            }
            Assert.True(newEvent.Locations.Where(x => x.Value.Contains("Study")).Count() == people.Count());
        }
    }
}


