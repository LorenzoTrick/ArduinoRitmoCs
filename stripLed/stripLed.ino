#include <Adafruit_NeoPixel.h>
#include <Thread.h>
#define pin1 11
#define pin2 10
#define pin3 9
#define pin4 8
#define nLed 15
#define b1 7

bool b1ON = false;

const int GREEN = 1;
const int RED = 2;
const int BLUE= 3;

Thread tButtons = Thread();

Adafruit_NeoPixel strip1(nLed, pin1, NEO_GRB);
Adafruit_NeoPixel strip2(nLed, pin2, NEO_GRB);
//Adafruit_NeoPixel strip3(nLed, pin3, NEO_GRB);
//Adafruit_NeoPixel strip4(nLed, pin4, NEO_GRB);

int v1[15] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
int v2[15] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
//int v3[15] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
//int v4[15] = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

void setup() {
  Serial.begin(57600);
  pinMode (b1,INPUT);
  strip1.setBrightness(100);
  strip1.begin();
  strip2.setBrightness(100);
  strip2.begin();
//  strip3.setBrightness(100);
//  strip3.begin();
//  strip4.setBrightness(100);
//  strip4.begin();
  tButtons.setInterval(1);
  tButtons.onRun(controllaBottoni);
}

void controllaBottoni(){
   if(digitalRead(b1) == HIGH && b1ON == false){
      Serial.print('A');
      b1ON = true;
   }else if(digitalRead(b1) == LOW && b1ON == true){
      Serial.print('a');
      b1ON = false;
   }
}

void loop() {
  
  
  int var = 0;
  while(Serial.available()<1)if(tButtons.shouldRun())tButtons.run();
  
  var = Serial.read();
//  v4[0] = var%4;
  var /= 4;
//  v3[0] = var%4;
  var /= 4;
  v2[0] = var%4;
  var /= 4;
  v1[0] = var%4;
  
  for (int i = 0; i < 15; i++)
  {
    
        if(v1[i] == GREEN) strip1.setPixelColor(i,255,0,0);
        else if(v1[i] == RED) strip1.setPixelColor(i,0,255,0); 
        else if(v1[i] == BLUE) strip1.setPixelColor(i,0,0,255);
        else if(v1[i] == 0) strip1.setPixelColor(i,0,0,0); 
        strip1.show();
        if(v2[i] == GREEN) strip2.setPixelColor(i,255,0,0);
        else if(v2[i] == RED) strip2.setPixelColor(i,0,255,0); 
        else if(v2[i] == BLUE) strip2.setPixelColor(i,0,0,255);
        else if(v2[i] == 0) strip2.setPixelColor(i,0,0,0); 
        strip2.show();
//        if(v3[i] == GREEN) strip3.setPixelColor(i,255,0,0);
//        else if(v3[i] == RED) strip3.setPixelColor(i,0,255,0); 
//        else if(v3[i] == BLUE) strip3.setPixelColor(i,0,0,255);
//        else if(v3[i] == 0) strip3.setPixelColor(i,0,0,0); 
//        strip3.show();
//        if(v4[i] == GREEN) strip4.setPixelColor(i,255,0,0);
//        else if(v4[i] == RED) strip4.setPixelColor(i,0,255,0); 
//        else if(v4[i] == BLUE) strip4.setPixelColor(i,0,0,255);
//        else if(v4[i] == 0) strip4.setPixelColor(i,0,0,0); 
//        strip4.show();
  }
  for (int i = 14; i > 0; i--)
    {
        v1[i] = v1[i - 1];
        v2[i] = v2[i - 1];
//        v3[i] = v3[i - 1];
//        v4[i] = v4[i - 1];
        
    }
    v1[0] = 0;  
    v2[0] = 0; 
//    v3[0] = 0;  
//    v4[0] = 0;
  
}
