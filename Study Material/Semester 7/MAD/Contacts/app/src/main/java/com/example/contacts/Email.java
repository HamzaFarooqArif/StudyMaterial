package com.example.contacts;


import androidx.appcompat.app.AppCompatActivity;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class Email extends AppCompatActivity {

    public EditText mEmail;
    public EditText mSubject;
    public  EditText mBody;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_email);
        Intent intent = getIntent();
        String str = intent.getStringExtra("Email");

        mEmail = (EditText)findViewById(R.id.editTextEmail);
        mSubject = (EditText)findViewById(R.id.editTextsubject);
        mBody = (EditText)findViewById(R.id.editTextBody);
        mEmail.setText(str);
    }
    public void sendEmail(View v)
    {
        String email = mEmail.getText().toString().trim();
        String subject = mSubject.getText().toString().trim();
        String message = mBody.getText().toString().trim();

        JavaMailAPI javaMailAPI = new JavaMailAPI(this,email,subject,message);
        javaMailAPI.execute();

    }
}
