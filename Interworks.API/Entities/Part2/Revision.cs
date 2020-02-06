using System;
using Interworks.API.Interfaces;

namespace Interworks.API.Entities.Part2 {
    public class Revision : IPrimaryEntity {
        public Guid id { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset? updatedAt { get; set; }
        
        //for every change in data, I need time off occurrence and the change of data from -> to
        
    }
}

//Create field for all users
//add the field question textbox = Your name
//select a user and add textbox = "Alex" value to answer the Your name question createdAt is set for this data
//select the user again and change the value of the textbox = "Maria" old data which is textbox = "Alex"
//now textbox = "Alex" will have a deletedAt which is older in time than the textbox = "Maria" createdAt  
//if I want the history of change occurred I will query for the user which is type client get all data
//findDeleted will return all the data that was deleted and I can order them by createdA
