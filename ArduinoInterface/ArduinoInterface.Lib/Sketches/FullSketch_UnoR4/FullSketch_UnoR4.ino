#include "Arduino_LED_Matrix.h"

ArduinoLEDMatrix matrix;

void processSerialCommand();
void handleMatrixUpdateCommand();

void setup() {
  Serial.begin(115200);
  matrix.begin();
}

// int count = 0;
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
  // switch (count) {
  //   case 0:
  //     matrix.loadFrame(heart);
  //     break;

  //   case 500:
  //     matrix.loadFrame(clear);
  //     break;
  // }

  // count++;
  // if (count >= 1000)
  //   count = 0;

  processSerialCommand();
  delay(1);
}

void processSerialCommand() {
  if (Serial.available() >= sizeof(int)) {
    // Read the incoming command
    int command;
    Serial.readBytes((char*)&command, sizeof(int));

    // Use a switch-case to handle the command
    switch (command) {
      case 1:  // ArduinoLEDMatrixUpdate
        handleMatrixUpdateCommand();
        break;
      case 2:  // Command2
        // handle command 2
        break;
        // add cases for more commands up to 12...
    }
  }
}

void handleMatrixUpdateCommand() {
  // This assumes that if ArduinoLEDMatrixUpdate command was sent, the LED state data will follow immediately
  if (Serial.available() >= 12) {
    // Read and handle the LED state data
    for (int i = 0; i < 3; i++) {
      state[i] = 0;
      for (int j = 0; j < 4; j++) {
        state[i] |= ((uint32_t)Serial.read()) << (j * 8);
      }
    }
    matrix.loadFrame(state);

    // Send "done" signal
    Serial.println("done");
  }
}
