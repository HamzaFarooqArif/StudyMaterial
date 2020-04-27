package com.example.datasharing;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


    }

    public void SendAnEmail(View view)
    {
        Intent n = new Intent(this, Email.class);
        startActivity(n);
        Log.i("11", "Email Activity Started");
    }

    public void MakeCall(View view)
    {
        Intent n = new Intent(this, PhoneCall.class);
        startActivity(n);
        Log.i("11", "PhoneCall Activity Started");
    }

    public void MoveToSend(View v)
    {
        Intent p = new Intent(Intent.ACTION_SEND);
        p.setType("text/plain");
        startActivity(p);
        Log.i("11", "SendMessage Activity Started");
    }
}
