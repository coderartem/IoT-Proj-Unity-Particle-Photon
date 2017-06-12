/*
 * Project UNITY-CONTROLLER-FIRMWARE
 * Description: UDP controller for Unity
 * Author: Brett Ian Balogh
 * Email: brettbalogh@gmail.com
 * Date: April 11, 2017
 * License: CC-BY-SA-NC
 */

// Include Libraries
 #include <Particle.h>
 #include <simple-OSC.h>
 #include <Wire.h>
 #include <Adafruit_MMA8451.h>
 //#include <Adafruit_Sensor.h>
 #include <Adafruit_DRV2605.h>

int buzz = D3;
// Create an instance of the haptic driver
 Adafruit_DRV2605 drv;
 // Create an instance of the accelerometer
 Adafruit_MMA8451 mma = Adafruit_MMA8451();
// Create some variable to hold accelerometer data
double accelX = 0;
double accelY = 0;
double accelZ = 0;
// Create a variable to hold the time
int theTime;
// Create an instance of UDP
UDP Udp;
// Variable for local IP address
String localIpString;
// !!IMPORTANT!!
// Change IP address to match that of the computer running Unity
IPAddress outIp(192,168,1,142);//your computer IP
unsigned int outPort = 8000; //computer incoming port
//
// Setup
//
void setup() {

    drv.begin();
    drv.selectLibrary(1);
    drv.setMode(DRV2605_MODE_INTTRIG);

    // Start the serial port for debugging
    Serial.begin(9600);
    // Set up the Accelerometer
    Serial.println("Adafruit MMA8451 test!");
    if (! mma.begin()) {
        Serial.println("Couldnt start");
        // next line blocks if accelerometer isn't found. Not desirable.
        // while (1);
    }
    Serial.println("MMA8451 found!");
    mma.setRange(MMA8451_RANGE_2_G);
    Serial.print("Range = "); Serial.print(2 << mma.getRange());
    Serial.println("G");
    // Set up cloud variables for accelerometer data
    Particle.variable("X", accelX);
    Particle.variable("Y", accelY);
    Particle.variable("Z", accelZ);
    // Set the local IP address
    localIpString = WiFi.localIP();
    // Start UDP
    Udp.begin(0);
    // Set up cloud variables for time and IP address
    Particle.variable("time", theTime);
    Particle.variable("localIP", localIpString);
    delay(1000);
}
//
// Main loop
//
void loop() {

    // Send time to Unity
    theTime = millis();
    sendTimeToUnity(theTime);
    /* Get a new sensor event */
    sensors_event_t event;
    mma.getEvent(&event);
    // store accelerometer values
    accelX = event.acceleration.x;
    accelY = event.acceleration.y;
    accelZ = event.acceleration.z;
    Serial.println(accelX);
    // send accelerometer data to Unity
    sendAccelToUnity(accelX, accelY, accelZ);
    /* Get the orientation of the sensor */
    uint8_t orientation = mma.getOrientation();
    sendOrientationToUnity(orientation);
    Serial.println();
    delay(500);
}
//
//    functions
//
void sendTimeToUnity(int t){
    OSCMessage outMessage("/time");
    outMessage.addInt(t);
    outMessage.send(Udp,outIp,outPort);
}

void sendAccelToUnity(double x, double y, double z){
    OSCMessage outMessage("/accel");
    outMessage.addFloat(x);
    outMessage.addFloat(y);
    outMessage.addFloat(z);
    outMessage.send(Udp,outIp,outPort);
}

void sendOrientationToUnity(uint8_t o){
    int orientOut=8;

    switch (o) {
    case MMA8451_PL_PUF:
    orientOut = 1;
  //  Buzz(1);
    Motor(4);
    break;

    case MMA8451_PL_PUB:
    orientOut = 2;
    break;

    case MMA8451_PL_PDF:
    orientOut = 3;
  //  Buzz(3);
    Motor(1);
    break;

    case MMA8451_PL_PDB:
    orientOut = 4;
    break;

    case MMA8451_PL_LRF:
    orientOut = 5;
  //  Buzz(4);
    Motor(3);
    break;

    case MMA8451_PL_LRB:
    orientOut = 6;
    break;

    case MMA8451_PL_LLF:
    orientOut = 7;
  //  Buzz(2);
    Motor(2);
    break;

    case MMA8451_PL_LLB:
    orientOut = 8;
    break;

    }

    OSCMessage outMessage("/orient");
    outMessage.addInt(orientOut);
    outMessage.send(Udp,outIp,outPort);
  }
/*
    void Buzz(uint8_t x){

      switch (x){

        case 1:
          tone(buzz,300);
          delay(400);
          tone(buzz,500);
          delay(200);
          tone(buzz,300);
          delay(300);
          noTone(buzz);
        break;

        case 2:
          tone(buzz,100);
          delay(700);
          tone(buzz,200);
          delay(400);
          noTone(buzz);
        break;

        case 3:
          for(uint8_t i=0;i<20;i++){
            tone(buzz,i*50);
            delay(50);
          }
          noTone(buzz);
        break;

        case 4:
          for(uint8_t i=0;i<10;i++){
            tone(buzz,1100-i*100);
            delay(100);
          }
          noTone(buzz);
        break;
      }
    }
*/
    void Motor(uint8_t y){

      switch (y){

        case 1:
          drv.setWaveform(0,52); //start forming wave, effect
          drv.setWaveform(1,0);   //stop forming wave
          drv.go();
        break;

        case 2:
          drv.setWaveform(0,1);
          drv.setWaveform(1,0);
          drv.go();
        break;

        case 3:
          drv.setWaveform(0,16);
          drv.setWaveform(1,0);
          drv.go();
        break;

        case 4:
          drv.setWaveform(0,14);
          drv.setWaveform(1,0);
          drv.go();
        break;
      }
    }


//
// End of Program
//
