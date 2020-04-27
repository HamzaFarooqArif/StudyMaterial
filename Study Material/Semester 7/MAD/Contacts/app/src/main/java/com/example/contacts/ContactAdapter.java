package com.example.contacts;

import android.content.Context;
import android.database.Cursor;
import android.provider.ContactsContract;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CursorAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.nio.LongBuffer;
import java.util.ArrayList;

public class ContactAdapter extends ArrayAdapter {

    int Layout_Id;
    Cursor cursor;
    ArrayList<ContactInfo> contacts = new ArrayList<>();
    ArrayList<String> mnames = new ArrayList<String>();
    ArrayList<String> mphonenumbers = new ArrayList<String>();
    ArrayList<String> memails = new ArrayList<String>();
    public ContactAdapter(Context context, ArrayList<ContactInfo> mcontacts) {
        super(context, 0);
        contacts = mcontacts;
        Layout_Id = R.layout.contact_layout;
    }
    public ContactAdapter(Context context, Cursor data) {
        super(context, 0);
        cursor = data;
        Layout_Id = R.layout.contact_layout;
    }


    public ContactAdapter(Context context, Cursor data, int LayoutId) {
        super(context, 0);
        Layout_Id = LayoutId;
        cursor = data;
    }

    @Override
    public int getCount() {
        return contacts.size();
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater mInflater = (LayoutInflater) this.getContext().
                getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        view = mInflater.inflate(Layout_Id, parent, false);
        Log.d("komal1","komal1");
        TextView name = (TextView) view.findViewById(R.id.Name);
        TextView phonenumber = (TextView) view.findViewById(R.id.Number);
        TextView email = (TextView) view.findViewById(R.id.Email);
        ImageView image= (ImageView) view.findViewById(R.id.imageView);
        Log.d("komal2","komal2");
        name.setText(contacts.get(position).name);
        if(contacts.get(position).email != null) {
            email.setText(contacts.get(position).email);
        }
        if(contacts.get(position).phonenumber != null) {
            phonenumber.setText(contacts.get(position).phonenumber);
        }
        Log.d("komal3","komal3");
        return view;

    }
}
