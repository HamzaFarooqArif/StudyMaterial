package com.example.contacts;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.net.Uri;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.util.Log;
import android.view.View;
import android.widget.EditText;

public class msg extends AppCompatActivity {

    private static final int MY_PERMISSIONS_REQUEST_SEND_SMS = 1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Intent intent = getIntent();
        String str = intent.getStringExtra("phonenumber");
        EditText n=(EditText)findViewById(R.id.editText);
        Log.e("hi",str+"hiiiii");
        n.setText(str);
        setContentView(R.layout.activity_msg);
    }
    private void checkForSmsPermission() {
        if (ActivityCompat.checkSelfPermission(this,
                Manifest.permission.SEND_SMS) !=
                PackageManager.PERMISSION_GRANTED) {
            Log.d("SMS_Sending ", "getString(R.string.permission_not_granted)");

            ActivityCompat.requestPermissions(this,
                    new String[]{Manifest.permission.SEND_SMS},
                    MY_PERMISSIONS_REQUEST_SEND_SMS);
        } else {
            Log.d("SMS_Sending ", "getString(R.string.permission_granted)");

        }
    }

    public void sendMsg(View v)
    {


        // Intent callIntent = new Intent(Intent.ACTION_DIAL);
        //callIntent.setData(Uri.parse("tel:0377778888"));

        //Uri.parse("geo:38.0316114,-78.5107279?z=11");
        //Uri.parse("url:www.gmail.com");








        checkForSmsPermission();
        EditText n=findViewById(R.id.editText);

        EditText m=findViewById(R.id.editText2);

        try {
            SmsManager s = SmsManager.getDefault();

            s.sendTextMessage(n.getText().toString(), null, m.getText().toString(), null, null);
        }catch(Exception e)
        {
            Log.d("SMS_Sending ", e.getMessage());
        }

    }
}
