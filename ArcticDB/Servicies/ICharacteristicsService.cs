using ArcticDB.Model;
using System;
using System.Collections.Generic;

namespace ArcticDB.Servicies
{
    internal interface ICharacteristicsService
    {
        List<Characteristic> getAllCharacteristics();
        Characteristic addCharacteristic(Characteristic characteristic);
        Characteristic removeCharacteristic(int characteristicId);
        void updateCharacteristic(Characteristic characteristic);
    }
}