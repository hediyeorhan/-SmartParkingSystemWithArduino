#define led1 3
#define led2 4
#define led3 5
#define fan1 6
#define fan2 7
#define sensor A0
#define buzzer 10

char katlar[2][3] = {{'0', '0', '0'}, {'0', '0', '0'}};
int aracsayisi = 0;
int arac;
int timer = 0;
int sensorDeger;
void setup() {
  Serial.begin(9600);
  pinMode(led1, OUTPUT);
  pinMode(led2, OUTPUT);
  pinMode(led3, OUTPUT);
  pinMode(fan1, OUTPUT);
  pinMode(fan2, OUTPUT);
  pinMode(buzzer, OUTPUT);
  pinMode(sensor, INPUT);



  cli();

  // Timer1 kesmesi ayarlanıyor
  TCNT1  = 0;
  TCCR1A = 0;
  TCCR1B = 0;
  OCR1A = 15624;  // Bir saniye çalışması için gerekli zaman kesmesi frekansı
  TCCR1B |= (1 << WGM12);
  TCCR1B |= (1 << CS12) | (1 << CS10);
  TIMSK1 |= (1 << OCIE1A);
  sei();
}


ISR(TIMER1_COMPA_vect) {

  timer++;

  if (timer == 2) // iki saniyelik bir timer tutuldu.
  {
    timer = 0;
    sensorDeger = analogRead(sensor);

    Serial.println(sensorDeger);
    Serial.print("-");
    
    if (sensorDeger > 800)
    {
      //Serial.print("Duman !!");

      digitalWrite(buzzer, HIGH);
    }
    else
    {
      //digitalWrite(led,LOW);
      digitalWrite(buzzer, LOW);
    }

  }

}

void loop() {

  while (Serial.available())
  {
    for (int katx = 0; katx < 2; katx++)
    {
      for (int katy = 0; katy < 3; katy++)
      {
        int arac = Serial.read();
        if (aracsayisi < 6 && arac == '1')
        {
          katlar[katx][katy] = arac;
          aracsayisi++;
        }
        else if (arac == '0' && aracsayisi != 0)
        {
          katlar[katx][katy] = arac;
          aracsayisi--;
        }
        if (aracsayisi >= 1)
        {
          //Serial.println("Led1 yak");
          digitalWrite(led1, HIGH);
          digitalWrite(fan1, HIGH);
        }
        if (aracsayisi > 3)
        {
          //Serial.println("Led2 yak");
          digitalWrite(led2, HIGH);
          digitalWrite(fan2, HIGH);
        }
        if (aracsayisi >= 6)
        {
          //Serial.println("Otopark dolu !");
          digitalWrite(led3, HIGH);
          break;
        }
        else if (aracsayisi <= 6)
        {
          //Serial.println("Otoparkta boşluk var !");
          digitalWrite(led3, LOW);
        }
      }
    }
  }
}
