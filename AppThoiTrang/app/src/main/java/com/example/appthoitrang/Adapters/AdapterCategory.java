package com.example.appthoitrang.Adapters;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.appthoitrang.ProductCateActivity;
import com.example.appthoitrang.R;

public class AdapterCategory extends RecyclerView.Adapter<AdapterCategory.PosHolder> {
    private Context mContext;

    public AdapterCategory(Context context) {
        this.mContext = context;
    }

    @NonNull
    @Override
    public AdapterCategory.PosHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.category_list,parent, false);

        return new PosHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull AdapterCategory.PosHolder holder, int position) {
holder.getImgCate().setOnClickListener(new View.OnClickListener() {
    @Override
    public void onClick(View view) {
//        onClickProductCate(id);
    }
});
    }

    private void onClickProductCate(int id){
        Intent intent = new Intent(mContext, ProductCateActivity.class);
        Bundle bundle = new Bundle();
        bundle.putSerializable("id_category", id);
        intent.putExtras(bundle);
        mContext.startActivity(intent);
    }
    @Override
    public int getItemCount() {
        return 0;
    }

    public class PosHolder extends RecyclerView.ViewHolder {
        ImageView imgCate;
        TextView nameCate;
        TextView desCate;

        public PosHolder(@NonNull View itemView) {
            super(itemView);
            imgCate = itemView.findViewById(R.id.cate_image);
            nameCate = itemView.findViewById(R.id.cate_name);
            desCate = itemView.findViewById(R.id.desCate);
        }

        public ImageView getImgCate() {
            return imgCate;
        }
    }
}
