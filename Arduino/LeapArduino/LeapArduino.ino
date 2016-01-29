#include <Servo.h>

Servo ServoInd;

void setup() {
  Serial.begin(9600);
  ServoInd.attach(7);

}

void movServo(Servo ServoInd, int pos, int delayServo)
{
  if(pos >= 0 && pos <= 180)
  {
    ServoInd.write(pos);
    delay(delayServo);
  }
}

void loop() {

  int pos;

  while (Serial.available())
  {

    // Serial.setTimeout(16);
    pos = Serial.read();
    
    movServo(ServoInd, pos, 15);
    
  }
}
