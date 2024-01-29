﻿using Core.Persistance.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Car : Entity<Guid>
{
    public Guid ModelId { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindexScore { get; set; }
    public CarState CarState { get; set; }


    public virtual Model? Model { get; set; }

    public Car()
    {

    }


    public Car(
        Guid id,
        Guid modelId,
        CarState carState,
        int kilometer,
        short modelYear,
        string plate,
        short minFindexScore
        ):this()
    {
        Id= id;
        ModelId= modelId;
        ModelYear= modelYear;
        MinFindexScore= minFindexScore;
        CarState = carState;
        Kilometer= kilometer;
        Plate= plate;

    }

    


}