package com.example.appthoitrang;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.appthoitrang.Models.CustomerMangment;
import com.example.appthoitrang.R;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class RegisterActivity extends AppCompatActivity {
    private TextView oldUserTxtView;
    private Button sing_up_btn;
    Host host = new Host();
    private String URL = "http://" + host.getHost() + ":8183/api/register";
    CustomerMangment customerMangment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        oldUserTxtView = findViewById(R.id.old_user_txtView);
        sing_up_btn = findViewById(R.id.sign_up_btn);
        oldUserTxtView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
                startActivity(intent);
                finish();
            }
        });
    }

    private void actionRegister(View view) {
        String name = ((EditText) findViewById(R.id.fName_edTxt)).getText().toString();
        String email = ((EditText) findViewById(R.id.email_edTxt)).getText().toString();
        String password = ((EditText) findViewById(R.id.password_edTxt)).getText().toString();
        String phone = ((EditText) findViewById(R.id.phone_no_edTxt)).getText().toString();
        String address = ((EditText) findViewById(R.id.dob_edTxt)).getText().toString();
        String cfpassword = ((EditText) findViewById(R.id.confirm_psw_edTxt)).getText().toString();
        if (!password.equals(cfpassword)) {
            Toast.makeText(this, "Password Mismatch", Toast.LENGTH_SHORT).show();
        } else if (!name.equals("") && !email.equals("") && !password.equals("") && !phone.equals("") && !address.equals("") && !cfpassword.equals("")) {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, URL, new Response.Listener<String>() {
                @Override
                public void onResponse(String response) {
                    try {
                        JSONObject object = new JSONObject(response);
                        if (object.getBoolean("result") == true) {
                            Toast.makeText(getApplicationContext(), object.getString("message"), Toast.LENGTH_SHORT).show();
                            Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
                            startActivity(intent);
                            finish();
                            sing_up_btn.setClickable(false);
                        } else if (object.getBoolean("result") == false) {
                            Toast.makeText(getApplicationContext(), object.getString("message"), Toast.LENGTH_SHORT).show();
                        }
                    } catch (JSONException ex) {
                    }
                }
            }
                    , new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                    Toast.makeText(getApplicationContext(), error.toString().trim(), Toast.LENGTH_SHORT).show();
                }
            }
            ){
                @Override
                protected Map<String, String> getParams() throws AuthFailureError {
                    Map<String, String> data = new HashMap<>();
                    data.put("name", name);
                    data.put("email", email);
                    data.put("password", password);
                    data.put("phone", phone);
                    data.put("address", address);
                    return data;
                }
            };
            RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
            requestQueue.add(stringRequest);
        }
    }
}