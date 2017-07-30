using System.Collections;
using System.Collections.Generic;

public class RoomsRegister : IEnumerable<int>
{
    private readonly List<Pet> rooms;
    private readonly int centerRoom;

    public RoomsRegister(int roomsNumber)
    {
        this.centerRoom = roomsNumber / 2;
        this.rooms = new List<Pet>(new Pet[roomsNumber]);
    }

    public IEnumerator<int> GetEnumerator()
    {
        int step = 1;

        yield return this.centerRoom;

        while (step <= this.centerRoom)
        {
            yield return this.centerRoom - step;

            yield return this.centerRoom + step++;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Pet this[int roomIndex]
    {
        get => this.rooms[roomIndex];
        set => this.rooms[roomIndex] = value;
    }
}