package com.example.contacts;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.cursoradapter.widget.SimpleCursorAdapter;

import android.Manifest;
import android.app.Activity;
import android.content.ContentResolver;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.media.Image;
import android.net.Uri;
import android.os.Bundle;
import android.provider.ContactsContract;
import android.provider.UserDictionary;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.PopupMenu;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
//import android.SimpleCursorAdapter;

class ContactInfo {
    String name;
    String phonenumber;
    String email;
    Image myimage;

    ContactInfo(String name, String email, String phonenumber, Image myimage) {
        this.name = name;
        this.email = email;
        this.phonenumber = phonenumber;
        this.myimage = myimage;
    }
}
    public class MainActivity extends AppCompatActivity {
    ListView listView;
        int selectedItemIndex=0;
    ArrayList<ContactInfo> Contacts= new ArrayList<>();
    ArrayList<String> StoreContacts;
    ArrayList<String> names = new ArrayList<String>();
    ArrayList<String> phonenumbers = new ArrayList<String>();
    ArrayList<String> emails = new ArrayList<String>();
    Cursor cursor;
    String name, phonenumber, email;


    public static final int RequestPermissionCode = 1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        listView = (ListView) findViewById(R.id.listView);

        //button = (Button)findViewById(R.id.button1);
        EnableRuntimePermission();
        StoreContacts = new ArrayList<String>();
        //  GetContactsIntoArrayList();
        //  arrayAdapter = new ArrayAdapter<String>(MainActivity.this,R.layout.contact_item, StoreContacts);
        // listView.setAdapter(arrayAdapter);

       // testSimpleAdpter();
        testCustomViewAdapter();
    }

    public void testSimpleAdpter() {
        cursor = getContentResolver().query(ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null, null, null, null);

        // Defines a list of columns to retrieve from the Cursor and load into an output row
        String[] wordListColumns =
                {
                        ContactsContract.CommonDataKinds.Phone.DISPLAY_NAME,   // Contract class constant containing the word column name
                        ContactsContract.CommonDataKinds.Phone.NUMBER  // Contract class constant containing the locale column name
                };

// Defines a list of View IDs that will receive the Cursor columns for each row
        int[] wordListItems = {R.id.Name, R.id.Number};

// Creates a new SimpleCursorAdapter
        SimpleCursorAdapter cursorAdapter = new SimpleCursorAdapter(
                getApplicationContext(),               // The application's Context object
                R.layout.contact_layout,                  // A layout in XML for one row in the ListView
                cursor,                               // The result from the query
                wordListColumns,                      // A string array of column names in the cursor
                wordListItems,                        // An integer array of view IDs in the row layout
                0);                                    // Flags (usually none are needed)

// Sets the adapter for the ListView
        listView.setAdapter(cursorAdapter);
    }


    public void testCustomViewAdapter() {
        //cursor = getContentResolver().query(ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null, null, null, null);
        //cursor.moveToFirst();
        //Log.d("testArray", cursor.toString());
        //ContactAdapter contactAdapter = new ContactAdapter(MainActivity.this, cursor);
        //listView.setAdapter(contactAdapter);
        getNameEmailDetails();
        ContactAdapter contactAdapter = new ContactAdapter(MainActivity.this, Contacts);
        Log.d("hi","hi");
        listView.setAdapter(contactAdapter);
        Log.d("hi","hi");
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView parent, View v, int i, long id) {

                selectedItemIndex=i;
                loadPopUpMenu(v);

            }
        });


    }

    public void getNameEmailDetails(){
        int i = 0;
        ContentResolver cr = getContentResolver();
        Cursor cur = cr.query(ContactsContract.Contacts.CONTENT_URI,null, null, null, null);
        if (cur.getCount() > 0) {
            while (cur.moveToNext()) {
                String id = cur.getString(cur.getColumnIndex(ContactsContract.Contacts._ID));
                Cursor cur1 = cr.query(
                        ContactsContract.CommonDataKinds.Email.CONTENT_URI, null,
                        ContactsContract.CommonDataKinds.Email.CONTACT_ID + " = ?",
                        new String[]{id}, null);
                Cursor cur2 = cr.query(
                        ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null,
                        ContactsContract.CommonDataKinds.Phone.CONTACT_ID + " = ?",
                        new String[]{id}, null);
                while (cur2.moveToNext() && cur1.moveToNext()) {
                    //to get the contact names
                    name=cur2.getString(cur2.getColumnIndex(ContactsContract.CommonDataKinds.Phone.DISPLAY_NAME));
                    Log.e("Name :", name);
                    phonenumber =cur2.getString(cur2.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER));
                    Log.e("PhoneNumber :", phonenumber);
                    email = cur1.getString(cur1.getColumnIndex(ContactsContract.CommonDataKinds.Email.DATA));
                    Log.e("Email", email);
                    if(email != null && phonenumber != null) {
                        ContactInfo c = new ContactInfo(name, email, phonenumber, null);
                        Contacts.add(c);
                    }
                    else if(email != null)
                    {
                        ContactInfo c = new ContactInfo(name, email, null, null);
                        Contacts.add(c);
                    }
                    else if(phonenumber != null)
                    {
                        ContactInfo c = new ContactInfo(name, null, phonenumber, null);
                        Contacts.add(c);
                    }
                    else
                    {
                        ContactInfo c = new ContactInfo(name, null, null, null);
                        Contacts.add(c);
                    }
                    i++;
                }
                cur1.close();
            }
        }
    }

    public void GetContactsIntoArrayList() {


        cursor = getContentResolver().query(ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null, null, null, null);


        while (cursor.moveToNext()) {


            name = cursor.getString(cursor.getColumnIndex(ContactsContract.CommonDataKinds.Phone.DISPLAY_NAME));

            phonenumber = cursor.getString(cursor.getColumnIndex(ContactsContract.CommonDataKinds.Phone.NUMBER));

            StoreContacts.add(name + " " + ":" + " " + phonenumber);
        }

        cursor.close();

    }


    public void EnableRuntimePermission() {

        if (ActivityCompat.shouldShowRequestPermissionRationale(
                MainActivity.this,
                Manifest.permission.READ_CONTACTS)) {

            Toast.makeText(MainActivity.this, "CONTACTS permission allows us to Access CONTACTS app", Toast.LENGTH_LONG).show();

        } else {

            ActivityCompat.requestPermissions(MainActivity.this, new String[]{
                    Manifest.permission.READ_CONTACTS}, RequestPermissionCode);

        }
    }

    @Override
    public void onRequestPermissionsResult(int RC, String per[], int[] PResult) {

        switch (RC) {

            case RequestPermissionCode:

                if (PResult.length > 0 && PResult[0] == PackageManager.PERMISSION_GRANTED) {

                    Toast.makeText(MainActivity.this, "Permission Granted, Now your application can access CONTACTS.", Toast.LENGTH_LONG).show();

                } else {

                    Toast.makeText(MainActivity.this, "Permission Canceled, Now your application cannot access CONTACTS.", Toast.LENGTH_LONG).show();

                }
                break;
        }

    }

        public void ShowPop(View v)
        {
            loadPopUpMenu(v);
        }
        private void loadPopUpMenu(View v)
        {

            PopupMenu popup = new PopupMenu(MainActivity.this, v,17);
            //Inflating the Popup using xml file
            popup.getMenuInflater().inflate(R.menu.popupmenu, popup.getMenu());

            //registering popup with OnMenuItemClickListener
            popup.setOnMenuItemClickListener(new PopupMenu.OnMenuItemClickListener() {
                public boolean onMenuItemClick(MenuItem item) {
                    onPopupSelected(item);
                    return true;
                }
            });

            popup.show();//showing popup menu
        }

        public boolean onPopupSelected(MenuItem item) {
            Toast.makeText(getApplicationContext(), "testing", Toast.LENGTH_SHORT).show();
            switch (item.getItemId()) {
                case R.id.pop1:
                {

                    Intent sendIntent = new Intent(Intent.ACTION_SENDTO);
                    //sendIntent.setAction(Intent.ACTION_SENDTO);
                    //sendIntent.putExtra(Intent.EXTRA_TEXT, "");
                    sendIntent.setType("text/plain");
                    sendIntent.putExtra("phonenumber", Contacts.get(selectedItemIndex).phonenumber);

                    // Set the data for the intent as the phone number.
                    sendIntent.setData(Uri.parse("smsto:"+Contacts.get(selectedItemIndex).phonenumber));

                    if (sendIntent.resolveActivity(getPackageManager()) != null) {
                    startActivity(sendIntent);
                    } else {
                    Log.e("SMS_Sending", "Can't resolve app for ACTION_SEND Intent.");
                    }
                    return true;
                }case R.id.pop2:
                {
                    //Intent detail = new Intent(Main2Activity.this, display.class);
                    //detail.putExtra("Name", countryNames[selectedItemIndex]);
                    //startActivity(detail);
                    Intent callIntent = new Intent(Intent.ACTION_DIAL);
                    callIntent.setData(Uri.parse("tel:"+Contacts.get(selectedItemIndex).phonenumber));
                    startActivity(callIntent);
                    return true;
                }
                case R.id.pop3:
                {


                    Intent myIntent = new Intent(MainActivity.this, Email.class);
                    myIntent.putExtra("Email", Contacts.get(selectedItemIndex).email);
                    MainActivity.this.startActivity(myIntent);
                    return true;
                }
                default:
                    return true;
            }


        }

}

   /* public void onActivityResult(int reqCode, int resultCode, Intent data) {
        super.onActivityResult(reqCode, resultCode, data);
        switch (reqCode) {
            case (PICK_CONTACT):
                if (resultCode == Activity.RESULT_OK) {
                    Uri contactData = data.getData();
                    Cursor c = managedQuery(contactData, null, null, null, null);
                    if (c.moveToFirst()) {
                        String id = c.getString(c.getColumnIndexOrThrow(ContactsContract.Contacts._ID));
                        String hasPhone = c.getString(c.getColumnIndex(ContactsContract.Contacts.HAS_PHONE_NUMBER));
                        try {
                            if (hasPhone.equalsIgnoreCase("1")) {
                                Cursor phones = getContentResolver().query(
                                        ContactsContract.CommonDataKinds.Phone.CONTENT_URI, null,
                                        ContactsContract.CommonDataKinds.Phone.CONTACT_ID + " = " + id,
                                        null, null);
                                phones.moveToFirst();
                                String cNumber = phones.getString(phones.getColumnIndex("data1"));
                                System.out.println("number is:" + cNumber);
                                txtphno.setText("Phone Number is: "+cNumber);
                            }
                            String name = c.getString(c.getColumnIndex(ContactsContract.Contacts.DISPLAY_NAME));
                            txtname.setText("Name is: "+name);
                            Log.i("info ",name);
                        }
                        catch (Exception ex)
                        {//
                        }
                    }
                }
                break;
        }
    }
}
*/