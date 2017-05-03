﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grid.Grid;

namespace Grid
{
    public sealed class Room
    {
        public int row { get; private set; }
        public int column { get; private set; }

        private Dictionary<Direction, Room> neighbors;

        public Room(int row, int column)
        {
            this.row = row;
            this.column = column;

            neighbors = new Dictionary<Direction, Room>();
        }

        public void Connect(Room roomToConnectWith, Direction direction)
        {
            if(neighbors.ContainsKey(direction))
            {
                neighbors.Remove(direction);
            }

            neighbors[direction] = roomToConnectWith;
        }

    }
}