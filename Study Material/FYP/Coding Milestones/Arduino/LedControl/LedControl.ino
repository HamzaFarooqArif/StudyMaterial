int ledPin = 6;
int brightness = 150;
int freq = 10;
char input;
void setup() {
pinMode(ledPin, OUTPUT);
Serial.begin(115200);
analogWrite(ledPin, brightness);
}

void loop() {
  if(Serial.available())
  {
    input = Serial.read();
    if(input == '=')
    {
      brightness += freq;
      Serial.print(brightness);
      Serial.println(" U");
    }
    if(input == '-')
    {
      brightness -= freq;
      Serial.print(brightness);
      Serial.println(" D");
    }
    analogWrite(ledPin, brightness); 
  }
}
