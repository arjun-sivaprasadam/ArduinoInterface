#include "Arduino_LED_Matrix.h"

ArduinoLEDMatrix matrix;

void setup() {
  matrix.begin();
}

uint8_t frame[8][12] = {
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
};

void clearmatrix() {
  frame[0][0] = 0;
  frame[0][11] = 0;
  frame[7][0] = 0;
  frame[7][11] = 0;
  frame[3][5] = 0;
  frame[3][6] = 0;
  frame[4][5] = 0;
  frame[4][6] = 0;
}


void loop() {
  matrix.renderBitmap(frame, 8, 12);
  delay(1000);
  matrix.renderBitmap(frame, 8, 12);
}