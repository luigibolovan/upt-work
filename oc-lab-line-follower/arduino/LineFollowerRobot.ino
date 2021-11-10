/*
 * "Politehnica" University of Timisoara
 * Computer Organization project
 * Name: Line follower robot
 * Authors: Luigi Bolovan & Bogdan Bercea
*/

unsigned int enA = 11; //enabler left motor
unsigned int enB = 10; //enabler right motor
unsigned int in1A = 9; // left 
unsigned int in2A = 8; // left
unsigned int in1B = 7; // right
unsigned int in2B = 6; // right

unsigned int MotorSpeed = 100; // default speed

/*
 * In case the sensor encounters some reflection in the receiver, with analogRead on the Serial Monitor a value between 950 and 980 can be seen.
 * Otherwise, the value seen on Serial Monitor variates from 30 to 50.
 * But in order to be sure, it will be checked if the value read is higher or lower than 512(since analogRead has a maximum resolution of 10 bits on the board that it is used)
*/
unsigned int leftSensor = A0; // analog pin used for reading the left sensor state
unsigned int centralSensor = A1; // analog pin used for reading the central sensor state
unsigned int rightSensor = A2; // analog pin used for reading the right sensor state

#define black2white 512

unsigned int leftSensorState; // left sensor state
unsigned int centralSensorState; // central sensor state
unsigned int rightSensorState; // right sensor state

void setup() {
  pinMode(11, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(10, OUTPUT);
  Serial.begin(9600);

  delay(5000); 
}

void loop() {

  //checking the states of the sensors...
  Serial.print("\nChecking the states of the sensors...\n\n");
  leftSensorState = analogRead(leftSensor);
  centralSensorState = analogRead(centralSensor);
  rightSensorState = analogRead(rightSensor);

  Serial.print("LeftSensorState:\n");
  Serial.print(leftSensorState);
  Serial.print("\n");
  Serial.print("CentralSensorState:\n");
  Serial.print(centralSensorState);
  Serial.print("\nRightSensorState:\n");
  Serial.print(rightSensorState);
  Serial.print("\n\n");


  if(leftSensorState > black2white //sees white
  && centralSensorState < black2white //sees black
  && rightSensorState > black2white) //sees white
  {
     Serial.print("Moving forward...\n\n");
     
      //set direction of rotation
     digitalWrite(in1A, HIGH);
     digitalWrite(in2A, LOW);

     //set speed for left motor
     analogWrite(enA, MotorSpeed);

    //set direction of rotation
    digitalWrite(in1B, HIGH);
    digitalWrite(in2B, LOW );

    //set speed for right motor
    analogWrite(enB, MotorSpeed);
  }

  if(leftSensorState < black2white //sees black
  && rightSensorState > black2white) //sees white
  {
    Serial.print("Turning left...\n\n");

    //set direction of rotation
     digitalWrite(in1A, HIGH);
     digitalWrite(in2A, LOW);

     //set speed for left motor
     analogWrite(enA, 0);

    //set direction of rotation
    digitalWrite(in1B, HIGH); 
    digitalWrite(in2B, LOW );

    //set speed for right motor
    analogWrite(enB, MotorSpeed);

    delay(10);
  }

  if(leftSensorState > black2white //sees white
  && rightSensorState < black2white) //sees black
  {
     Serial.print("Turning right...\n\n");
     //set direction of rotation
     digitalWrite(in1A, HIGH);
     digitalWrite(in2A, LOW);

     //set speed for left motor
     analogWrite(enA, MotorSpeed);

    //set direction of rotation
    digitalWrite(in1B, HIGH);
    digitalWrite(in2B, LOW );

    //set speed for right motor
    analogWrite(enB, 0);

   delay(10);
  }

  if(leftSensorState < black2white //sees black
  && centralSensorState < black2white //sees black
  && rightSensorState < black2white) //sees black
  {
    Serial.print("----Stopped----\n\n");

    //stop the motors
    analogWrite(enA, 0);
    analogWrite(enB, 0);
  }

  if(leftSensorState > black2white //sees white
  && centralSensorState > black2white //sees white
  && rightSensorState > black2white) // sees white
  {
    Serial.print("No line to follow... stopping... \n\n");

     //stop the motors
    analogWrite(enA, 0); 
    analogWrite(enB, 0); 

  }

}
