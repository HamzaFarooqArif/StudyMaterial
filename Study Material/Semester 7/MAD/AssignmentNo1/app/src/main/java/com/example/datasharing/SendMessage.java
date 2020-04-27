package com.example.datasharing;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import android.Manifest;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.telephony.SmsManager;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class SendMessage extends AppCompatActivity {

    final int Check_permission_send_code = 1;

    EditText mEditTextpNumber;
    EditText message;
    Button sendBtn;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_message);

        mEditTextpNumber = findViewById(R.id.editText);
        message = findViewById(R.id.editText2);
        sendBtn = findViewById(R.id.button2);
        sendBtn.setEnabled(false);

        if(CheckPermission(Manifest.permission.SEND_SMS))
        {
            sendBtn.setEnabled(true);
        }
        else {
            ActivityCompat.requestPermissions(this,
                    new String[]{Manifest.permission.SEND_SMS}, Check_permission_send_code);
        }
    }


    public void sendMyMessage(View v)
    {
        String phoneNumber = mEditTextpNumber.getText().toString();
        String txtMessage = message.getText().toString();
        if(!phoneNumber.isEmpty()
        || !txtMessage.isEmpty()) {
            if(CheckPermission(Manifest.permission.SEND_SMS)) {
                SmsManager smsManager = SmsManager.getDefault();
                smsManager.sendTextMessage(phoneNumber, null, txtMessage, null, null);
                Toast.makeText(this, "Message Successfully Sent!",Toast.LENGTH_SHORT ).show();
                Log.i("12", "Tried to send Message");
            }
            else{
                Toast.makeText(this, "Message not sent!",Toast.LENGTH_SHORT ).show();
            }
        }
        else
        {
            Toast.makeText(this, "Check Input Fields", Toast.LENGTH_SHORT).show();
        }

    }

    public boolean CheckPermission(String permission)
    {
        int checkPerm = ContextCompat.checkSelfPermission(this, permission);
        return (checkPerm == PackageManager.PERMISSION_GRANTED);
    }
}
