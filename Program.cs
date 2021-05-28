using System;
using System.Collections.Generic; // List
using System.Text.Json; // visual json


namespace Rocket_Elevators_Csharp_Controller
{
////////////////////////////// BATTERY CLASS //////////////////////////////
    class Battery
    {
        public int ID { get ; set;}
        public string status { get ; set;}
        public List<Column> columnsList { get ; set;}
        public List<FloorRequestButtons> floorRequestButtonsList { get ; set;}
        public int amountOfColumns { get ; set;}
        public int amountOfFloors { get ; set;}
        public int amountOfElevatorPerColumn { get ; set;}
        public int amountOfBasements { get ; set;}
        public Battery(int _id, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            ID = _id;
            status = "online";
            columnsList = new List<Column>() {};
            floorRequestButtonsList = new List<FloorRequestButtons>() {};
            amountOfColumns = _amountOfColumns;
            amountOfFloors = _amountOfFloors;
            amountOfElevatorPerColumn = _amountOfElevatorPerColumn;
            amountOfBasements = _amountOfBasements;
        }
////////////////////////////// createColumn //////////////////////////////
        public void createColumn(int _amountOfColumns, int _amountOfFloors, int _amountOfElevators)
        {
            for (int i = 0; i < _amountOfColumns; i++)
            {
                var column = new Column(i, _amountOfFloors, _amountOfElevators);
                this.columnsList.Add(column);
                this.columnsList[0].isBasement = true;
                if (this.columnsList[i].isBasement == false)
                {
                    var servedFloorMin = (i - 1) * (_amountOfFloors / (this.amountOfColumns -1));
                    var servedFloorMax = i * (_amountOfFloors / (this.amountOfColumns -1));
                    this.columnsList[i].servedFloors.Add(0);
                    this.columnsList[i].servedFloors.Add(servedFloorMin);
                    this.columnsList[i].servedFloors.Add(servedFloorMax);
                } else
                {
                    var servedFloorMin = i;
                    var servedFloorMax = i - this.amountOfBasements;
                    this.columnsList[i].servedFloors.Add(0);
                    this.columnsList[i].servedFloors.Add(-servedFloorMin);
                    this.columnsList[i].servedFloors.Add(servedFloorMax);
                }
              
            }
        }


////////////////////////////// assignElevator //////////////////////////////

        public void assignElevator(int _requestedFloor, string _direction)
        { 
             
            // create column
            createColumn(this.amountOfColumns, this.amountOfFloors, this.amountOfElevatorPerColumn);
            // create elevator
            for (int i = 0; i < this.amountOfColumns; i++)
            {
                columnsList[i].createElevator(this.amountOfFloors, this.amountOfElevatorPerColumn);

            } 
            
            // find best column
            var selectedColumnNumber = FindBestColumn(_requestedFloor, this.columnsList);
            Console.WriteLine("Colone " + selectedColumnNumber + " is selected");
            var selectedColumn = this.columnsList[selectedColumnNumber];
            // Set floor on scenario
            this.columnsList[1].elevatorsList[0].currentFloor = 20;
            this.columnsList[1].elevatorsList[1].currentFloor = 3;
            this.columnsList[1].elevatorsList[2].currentFloor = 13;
            this.columnsList[1].elevatorsList[3].currentFloor = 15;
            this.columnsList[1].elevatorsList[4].currentFloor = 6;
            // find best elevator

            for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
            {
                if (selectedColumn.elevatorsList[i].currentFloor == _requestedFloor)
                {
                    selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                    selectedColumn.status = "busy";
                    break;
                }
            }
            if (selectedColumn.status == "online")
            {
                for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
                {
                    if (selectedColumn.elevatorsList[i].currentFloor-_requestedFloor >= -1 && selectedColumn.elevatorsList[i].currentFloor-_requestedFloor <= 1)
                    {
                        selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                        selectedColumn.status = "busy";
                        break;
                    }
                }
            }
            if (selectedColumn.status == "online")
            {
                for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
                {
                    if (selectedColumn.elevatorsList[i].currentFloor-_requestedFloor >= -2 && selectedColumn.elevatorsList[i].currentFloor-_requestedFloor <= 2)
                    {
                        selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                        selectedColumn.status = "busy";
                        break;
                    }
                }
            }
            if (selectedColumn.status == "online")
            {
                for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
                {
                    if (selectedColumn.elevatorsList[i].currentFloor-_requestedFloor >= -3 && selectedColumn.elevatorsList[i].currentFloor-_requestedFloor <= 3)
                    {
                        selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                        selectedColumn.status = "busy";
                        break;
                    }
                }
            }
            if (selectedColumn.status == "online")
            {
                for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
                {
                    if (selectedColumn.elevatorsList[i].currentFloor-_requestedFloor >= -4 && selectedColumn.elevatorsList[i].currentFloor-_requestedFloor <= 4)
                    {
                        selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                        selectedColumn.status = "busy";
                        break;
                    }
                }
            }
            if (selectedColumn.status == "online")
            {
                for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
                {
                    if (selectedColumn.elevatorsList[i].currentFloor-_requestedFloor >= -5 && selectedColumn.elevatorsList[i].currentFloor-_requestedFloor <= 5)
                    {
                        selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                        selectedColumn.status = "busy";
                        break;
                    }
                }
            }
            if (selectedColumn.status == "online")
            {
                for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
                {
                    if (selectedColumn.elevatorsList[i].currentFloor-_requestedFloor >= -10 && selectedColumn.elevatorsList[i].currentFloor-_requestedFloor <= 10)
                    {
                        selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                        selectedColumn.status = "busy";
                        break;
                    }
                }
            }
            if (selectedColumn.status == "online")
            {
                for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
                {
                    if (selectedColumn.elevatorsList[i].currentFloor-_requestedFloor >= -20 && selectedColumn.elevatorsList[i].currentFloor-_requestedFloor <= 20)
                    {
                        selectedColumn.elevatorsList[i].floorRequestList.Add( _requestedFloor);
                        selectedColumn.status = "busy";
                        break;
                    }
                }
            }

            /// mouvement
            for (int i = 0; i < this.amountOfElevatorPerColumn; i++)
            {
               
                if (selectedColumn.elevatorsList[i].floorRequestList.Count > 0)
                {
                    selectedColumn.elevatorsList[i].Door.status = "closed";
                    selectedColumn.elevatorsList[i].status = "moving";
                    if (selectedColumn.elevatorsList[i].currentFloor < _requestedFloor)
                    {
                        var selectedElevator = selectedColumn.elevatorsList[i];
                        selectedElevator.direction = "up";
                        Console.WriteLine("Elevator " + selectedColumn.elevatorsList[i].ID + " is " + selectedColumn.elevatorsList[i].status + ' ' + selectedColumn.elevatorsList[i].direction);
                        for (int x = selectedElevator.currentFloor; x < _requestedFloor; x++)
                        {
                            selectedElevator.currentFloor = selectedElevator.currentFloor + 1;
                            Console.WriteLine("Floor : " + selectedElevator.currentFloor);
                            /* selectedElevator.floorRequestList.Remove(_requestedFloor); */
                        }
                    //// ouverture des porte    
                    selectedColumn.elevatorsList[i].Door.status = "opened";
                    Console.WriteLine("The door is " + selectedColumn.elevatorsList[i].Door.status);      
                    }
                    else if (selectedColumn.elevatorsList[i].currentFloor > _requestedFloor)
                    {
                        var selectedElevator = selectedColumn.elevatorsList[i];
                        selectedElevator.direction = "down";
                        Console.WriteLine("Elevator " + selectedColumn.elevatorsList[i].ID + " is " + selectedColumn.elevatorsList[i].status + ' ' + selectedColumn.elevatorsList[i].direction);
                        for (int x = selectedElevator.currentFloor; x > _requestedFloor; x--)
                        {
                            selectedElevator.currentFloor = selectedElevator.currentFloor - 1;
                            Console.WriteLine("Floor : " + selectedElevator.currentFloor);
                            /* selectedElevator.floorRequestList.Remove(_requestedFloor);  */
                        }   
                    //// ouverture des porte                         
                    selectedColumn.elevatorsList[i].Door.status = "opened";
                    Console.WriteLine("The door is " + selectedColumn.elevatorsList[i].Door.status);   
                    /* selectedColumn.requestElevator()     */            
                    }
                    else 
                    {
                        //// ouverture des porte                         
                        selectedColumn.elevatorsList[i].Door.status = "opened";
                        Console.WriteLine("The door is " + selectedColumn.elevatorsList[i].Door.status);   
                    }
                }
                
            }
                


            

        }




////////////////////////////// FIND BEST COLUMN //////////////////////////////

        public static int FindBestColumn(int _requestedFloor, List<Column> columnsList)
        {
            
            for (int i = 0; i < columnsList.Count; i++)
            {
                if (columnsList[i].servedFloors[1] <= _requestedFloor && columnsList[i].servedFloors[2] >= _requestedFloor || columnsList[i].servedFloors[1] >= _requestedFloor && columnsList[i].servedFloors[2] <= _requestedFloor)
                {      
                    var selectedColumn = i;
                    return selectedColumn;
                }
            }
            return 0;
        } 

    }    

////////////////////////////// Column CLASS //////////////////////////////

    class Column
    {
        public int ID { get ; set;} 
        public string status { get ; set;}
        public List<int> servedFloors { get ; set;}   
        public bool isBasement { get ; set;}   
        public List<Elevator> elevatorsList { get ; set;}   
        public List<int> callButtonsList { get ; set;}   
        public int amountOfElevators { get ; set;}  
        public Column(int _id, int _amountOfFloors, int _amountOfElevators)
        {
            ID = _id;
            status = "online";
            servedFloors = new List<int>() {};
            isBasement = false;
            elevatorsList = new List<Elevator>() {};
            callButtonsList = new List<int>() {};
            amountOfElevators = _amountOfElevators;
        }


////////////////////////////// Create ELEVATOR //////////////////////////////        
        public void createElevator(int _amountOfFloors, int _amountOfElevators)
        {
            for(int i = 0; i < _amountOfElevators; i++)
            {
                var elevator = new Elevator(i, _amountOfFloors);
                this.elevatorsList.Add(elevator);
            }
        }

////////////////////////////// requestElevator //////////////////////////////        

        public void requestElevator(int _requestedFloor, string _direction)
        {
            
            for (int i = 0; i < this.amountOfElevators; i++)
            {
                if (this.elevatorsList[i].floorRequestList.Count > 0)
                {
                    if (this.elevatorsList[i].currentFloor < _requestedFloor)
                    {
                        this.elevatorsList[i].Door.status = "closed";
                        Console.WriteLine("The door is " + this.elevatorsList[i].Door.status);  
                        var selectedElevator = this.elevatorsList[i];
                        selectedElevator.direction = "up";
                        Console.WriteLine("Elevator " + this.elevatorsList[i].ID + " is " + this.elevatorsList[i].status + ' ' + this.elevatorsList[i].direction);
                        for (int x = selectedElevator.currentFloor; x < _requestedFloor; x++)
                        {
                            selectedElevator.currentFloor = selectedElevator.currentFloor + 1;
                            Console.WriteLine("Floor : " + selectedElevator.currentFloor);
                            selectedElevator.floorRequestList.Remove(_requestedFloor);
                        }
                        //// ouverture des porte    
                        this.elevatorsList[i].Door.status = "opened";
                        Console.WriteLine("The door is " + this.elevatorsList[i].Door.status);  
                    }
                    else 
                    {
                        this.elevatorsList[i].Door.status = "closed";
                        Console.WriteLine("The door is " + this.elevatorsList[i].Door.status);
                        var selectedElevator = this.elevatorsList[i];
                        selectedElevator.direction = "down";
                        Console.WriteLine("Elevator " + this.elevatorsList[i].ID + " is " + this.elevatorsList[i].status + ' ' + this.elevatorsList[i].direction);
                        for (int x = selectedElevator.currentFloor; x > _requestedFloor; x--)
                            {
                                selectedElevator.currentFloor = selectedElevator.currentFloor - 1;
                                Console.WriteLine("Floor : " + selectedElevator.currentFloor);
                                selectedElevator.floorRequestList.Remove(_requestedFloor); 
                            } 
                        //// ouverture des porte                         
                        this.elevatorsList[i].Door.status = "opened";
                        Console.WriteLine("The door is " + this.elevatorsList[i].Door.status);       
                    }
                    
                }
                    
            }
               


        }
    }
////////////////////////////// Elevator CLASS //////////////////////////////
    class Elevator
    {
        public int ID { get ; set;}   
        public string status { get ; set;}   
        public int currentFloor { get ; set;}   
        public string direction { get ; set;}   
        public Door Door { get ; set;} 
        public List<int> floorRequestList { get ; set;}   
        public List<int> completedRequestsList { get ; set;}   
        public Elevator(int _id, int _amountOfFloors)
        {
            ID = _id;
            status = "idle";
            currentFloor = 0;
            direction = "idle";
            this.Door = new Door(_id);
            floorRequestList = new List<int>() {};
            completedRequestsList = new List<int>() {};
        }

    }
////////////////////////////// Door CLASS //////////////////////////////
    class Door
    {
        public int ID { get ; set;} 
        public string status { get ; set;} 
        public Door(int _id)
        {
            ID = _id;
            status = "opened";
        }
    }
////////////////////////////// CallButton CLASS //////////////////////////////
    class CallButton
    {
        public int ID { get ; set;} 
        public string status { get ; set;} 
        public int floor { get ; set;} 
        public string direction { get ; set;} 
        public CallButton(int _id, int _floor, string _direction)
        {
            ID = _id;
            status = "idle";
            floor = _floor;
            direction = _direction;
        }
    }
    ////////////////////////////// FloorRequestButtons CLASS //////////////////////////////
    class FloorRequestButtons
    {
        public int ID { get ; set;} 
        public string status { get ; set;} 
        public int floor { get ; set;} 
        public FloorRequestButtons(int _id, int _floor)
        {
            ID = _id;
            status = "idle";
            floor = _floor;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Battery battery1 = new Battery(1, 4, 60, 6, 5);
            battery1.assignElevator(8, "up");
            battery1.columnsList[1].requestElevator(0, "down");
        }    
    }
}
