package com.example.appthoitrang;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.appthoitrang.R;

public class ProfileFragment extends Fragment {
private static final String ARG_PARAM1 = "param1";
private static final String ARG_PARAM2 = "param2";

private String mParam1;
private String mParam2;

    public ProfileFragment() {
    }

    public static ProfileFragment newInstance (String param1, String param2){
        ProfileFragment profileFragment = new ProfileFragment();
        Bundle bundle = new Bundle();
        bundle.putString(ARG_PARAM1,param1);
        bundle.putString(ARG_PARAM1,param2);
        profileFragment.setArguments(bundle);
        return profileFragment;
    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }
    }
    public View onCreateView(LayoutInflater inflater , ViewGroup container , Bundle bundle){
        return inflater.inflate(R.layout.profile_fragment,container,false);
    }
}