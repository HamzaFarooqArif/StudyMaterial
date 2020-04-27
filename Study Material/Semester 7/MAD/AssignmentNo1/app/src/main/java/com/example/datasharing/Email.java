package com.example.datasharing;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class Email extends AppCompatActivity {


    public EditText mEditTextTo;
    public EditText mEditTextSubject;
    public EditText mEditTextMessage;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_email);
        mEditTextTo =findViewById(R.id.edit_text_to);
        mEditTextMessage =findViewById(R.id.edit_text_message);
        mEditTextSubject = findViewById(R.id.edit_text_subject);
        Button btn_Send = findViewById(R.id.button_send);
        btn_Send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                sendMail();
            }
        });


    }


    private void sendMail()
    {
        String mail = mEditTextTo.getText().toString().trim();
        String message = mEditTextMessage.getText().toString();
        String Sub = mEditTextSubject.getText().toString().trim();
        if(mail.trim().length() == 0 || !validEmail(mail))
        {
            Toast.makeText(this, "Invalid Recipient's Email", Toast.LENGTH_SHORT).show();
        }
        else if(message.trim().length() == 0 ) {
            Toast.makeText(this, "Enter Email Body", Toast.LENGTH_SHORT).show();
        }
        else {
        JavaMailAPI javaMailAPI = new JavaMailAPI(this, mail, Sub, message);
        javaMailAPI.execute();
        Log.i("14", "Tried to send Email");
        }
    }

    private boolean validEmail(String email) {
        String regex = "^[\\w-_\\.+]*[\\w-_\\.]\\@([\\w]+\\.)+[\\w]+[\\w]$";
        return email.matches(regex);
    }
}
