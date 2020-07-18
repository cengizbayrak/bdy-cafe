package com.bdy.cafe.handler;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.support.graphics.drawable.VectorDrawableCompat;
import android.support.v4.content.ContextCompat;
import android.support.v4.graphics.drawable.DrawableCompat;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatDelegate;

import com.bdy.cafe.R;
import com.bdy.cafe.runnable.InitialConnectionRunnable;
import com.bdy.cafe.utility.MyUtil;

/**
 * Created by cngz on 22.12.2016.
 * <p>
 * Check SQL connection and get settings on opening of the app
 */
public class InitConnectionHandler extends AsyncTask<Void, Void, Boolean> {
    private static final String TAG = "InitConnectionHandler";

    private Context context;
    private boolean showProgress;
    private ProgressDialog progressDialog;

    public InitConnectionHandler(Context context, boolean showProgress) {
        this.context = context;
        this.showProgress = showProgress;
    }

    @Override
    protected void onPreExecute() {
        if (progressDialog != null) {
            progressDialog.dismiss();
        }

        if (showProgress) {
            progressDialog = MyUtil.Global.getProgressDialog(context, R.string.server_connection_control, R.string.trying_connection_to_server, false);
            progressDialog.show();
        }
    }

    @Override
    protected Boolean doInBackground(Void... params) {
        InitialConnectionRunnable initialConnectionRunnable = new InitialConnectionRunnable();
        initialConnectionRunnable.run();
        return initialConnectionRunnable.getResult();
    }

    @Override
    protected void onPostExecute(Boolean aBoolean) {
        if (progressDialog != null) {
            progressDialog.dismiss();
        }

        if (!aBoolean) {
            AppCompatDelegate.setCompatVectorFromResourcesEnabled(true);
            Drawable icon = VectorDrawableCompat.create(context.getResources(), R.drawable.ic_error_black_24dp, null);
            if (icon != null) {
                icon = DrawableCompat.wrap(icon);
                DrawableCompat.setTint(icon, ContextCompat.getColor(context, R.color.snackbarErrorBackgroundColor));
            }
            AlertDialog.Builder builder = new AlertDialog.Builder(context)
                    .setCancelable(false)
                    .setTitle(R.string.server_connection_control)
                    .setMessage(R.string.server_connection_failed_contact_supervisor)
                    .setIcon(icon)
                    .setPositiveButton(R.string.retry_UPPER, new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            InitConnectionHandler handler = new InitConnectionHandler(context, true);
                            handler.execute();
                        }
                    })
                    .setNegativeButton(R.string.cancel_UPPER, new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            dialog.dismiss();
                        }
                    });
            builder.show();
        }
    }
}