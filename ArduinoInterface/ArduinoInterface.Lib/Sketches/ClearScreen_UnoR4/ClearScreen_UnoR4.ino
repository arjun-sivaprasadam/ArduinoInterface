#include "Arduino_LED_Matrix.h"

ArduinoLEDMatrix matrix;

void processSerialCommand();

void setup() {
  Serial.begin(115200);
  matrix.begin();
}

int count = 0;
uint32_t state[] = {
  0x00000000,
  0x00000000,
  0x00000000
};

const uint32_t happy[] = {
  0x19819,
  0x80000001,
  0x81f8000
};

const uint32_t heart[] = {
  0x3184a444,
  0x44042081,
  0x100a0040
};

const uint32_t clear[] = {
  0x00000000,
  0x00000000,
  0x00000000
};



void loop() {
  switch (count) {
    case 0:
      matrix.loadFrame(heart);
      break;

    case 500:
      matrix.loadFrame(clear);
      break;
  }

  count++;
  if (count >= 1000)
    count = 0;

  processSerialCommand();
  delay(1);
}

void processSerialCommand() {
  if (Serial.available() > 0) {
    // Read the incoming command
    String command = Serial.readStringUntil('\n');

    // Parse the command and extract the LED frames
    int i = 0;
    char* ptr = strtok((char*)command.c_str(), ",");
    while (ptr != NULL && i < 3) {
      state[i] = strtoul(ptr, NULL, 16);
      ptr = strtok(NULL, ",");
      i++;
    }

    // Light up the LEDs with the received frames
    for (i = 0; i < 3; i++) {
      analogWrite(ledPin, state[i]);
    }

    matrix.loadFrame(state);

    // Send "done" signal
    Serial.println("done");
  }
}