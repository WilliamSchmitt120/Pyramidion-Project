// Visual Micro is in vMicro>General>Tutorial Mode
// 
/*
    Name:       UnityLights.ino
    Created:	07/10/2020 15:10:14
    Author:     ETU\c.bentein
*/

// Define User Types below here or use a .h file
//


// Define Function Prototypes that use User Types below here or use a .h file
//


// Define Functions below here or use other .ino or cpp files
//

// The setup() function runs once each time the micro-controller starts

#include<Uduino.h>
Uduino uduino("uduinoBoard");

void setup()
{
  Serial.begin(9600);
  uduino.addCommand("victory", GoodEnding);
  uduino.addCommand("defeat", BadEnding);
}

void GoodEnding()
{
  Serial.println("I am BLUE!");
}

void BadEnding()
{
  Serial.println("I am RED!");
}
// Add the main program code into the continuous loop() function
void loop()
{
  uduino.update();
  delay(15);
}
