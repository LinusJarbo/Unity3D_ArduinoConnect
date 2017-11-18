//pins
int analogPin0 = 0;
int analogPin1 = 1;
int analogPin2 = 2;

//vars
int val = 0;           // variable to store the value read
byte incomingByte;
String str;

void setup() {
  Serial.begin(57600);
  
  while (!Serial);
  Serial.println("found serial");
}

void loop() {
  if (Serial.available() > 0){
    incomingByte = Serial.read();
    
    if(incomingByte == 65){//A
      val = analogRead(analogPin0);  
      Serial.println(String("A") + val);
      Serial.flush();
      }
    else if (incomingByte == 66){//B
      val = analogRead(analogPin1);
      Serial.println(String("B") + val);
      Serial.flush();
    }
    else if (incomingByte == 67){//C
      val = analogRead(analogPin2);
      Serial.println(String("C") + val);
      Serial.flush();
    }
    else if (incomingByte == 72){//H -> handshake
      Serial.println(String("H"));
      Serial.flush();
    }
  }
}



