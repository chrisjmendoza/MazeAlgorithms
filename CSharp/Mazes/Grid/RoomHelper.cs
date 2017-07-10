﻿using System;
using System.Collections.Generic;
using static Grid.Grid;

namespace Grid
{
    public sealed class RoomHelper
    {

        public static GridPosition GetNeighborLocation(Room room, Direction direction)
        {
            // moves up a row
            if (direction == Direction.NORTH) 
            {
                return new GridPosition(room.row - 1, room.column);
            }
            // moves back a row
            else if (direction == Direction.SOUTH) 
            {
                return new GridPosition(room.row + 1, room.column);
            }
            // moves left a column
            else if (direction == Direction.EAST) 
            {
                return new GridPosition(room.row, room.column + 1);
            }
            // moves right a column
            else if (direction == Direction.WEST) 
            {
                return new GridPosition(room.row, room.column - 1);
            }
            else
            {
                // There is no room in this direction
                throw new ArgumentException($"{direction} is not a valid direction."); 
            }
        }
        
        public static void ConnectRooms(Room roomOne, Room roomTwo, Direction directionFromRoomOneToRoomTwo)
        {
            roomOne.Connect(roomTwo, directionFromRoomOneToRoomTwo);

            if(directionFromRoomOneToRoomTwo == Direction.NORTH)
            {
                roomTwo.Connect(roomOne, Direction.SOUTH);
            }
            else if(directionFromRoomOneToRoomTwo == Direction.SOUTH)
            {
                roomTwo.Connect(roomOne, Direction.NORTH);
            }
            else if (directionFromRoomOneToRoomTwo == Direction.EAST)
            {
                roomTwo.Connect(roomOne, Direction.WEST);
            }
            else if (directionFromRoomOneToRoomTwo == Direction.WEST)
            {
                roomTwo.Connect(roomOne, Direction.EAST);
            }
        }

        /// <summary>
        /// This method finds all of the boundaries that each room is on. For example if a room is on the northern wall then it will have a boundary to the north.
        /// </summary>
        /// <param name="room"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static List<Direction> GetBoundriesRoomIsOn(Room room, int rows, int columns) 
        {
            List<Direction> edgeDirections = new List<Direction>();

            if (room.row == 0)
            {
                edgeDirections.Add(Direction.NORTH);
            }

            if (room.row == (rows - 1))
            {
                edgeDirections.Add(Direction.SOUTH);
            }

            if (room.column == 0)
            {
                edgeDirections.Add(Direction.WEST);
            }

            if (room.column == (columns - 1))
            {
                edgeDirections.Add(Direction.EAST);
            }

            return edgeDirections;
        }


    }
}
